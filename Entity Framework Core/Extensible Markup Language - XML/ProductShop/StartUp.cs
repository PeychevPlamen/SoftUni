using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Dtos.Export;
using ProductShop.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Text;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var dbContext = new ProductShopContext();

            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            string inputUsersXml = File.ReadAllText("../../../Datasets/users.xml");
            var inputProductsXml = File.ReadAllText("../../../Datasets/products.xml");
            var inputCatProdXml = File.ReadAllText("../../../Datasets/categories-products.xml");
            var inputCatXml = File.ReadAllText("../../../Datasets/categories.xml");

            // Console.WriteLine(ImportUsers(dbContext, inputUsersXml)); // 01. Import Users
            // Console.WriteLine(ImportProducts(dbContext, inputProductsXml)); // 02. Import Products
            // Console.WriteLine(ImportCategories(dbContext, inputCatXml)); // 03. Import Categories
            // Console.WriteLine(ImportCategoryProducts(dbContext, inputCatProdXml)); // 04. Import Categories and Products

            //Console.WriteLine(GetProductsInRange(dbContext)); // 05. Export Products In Range
            //Console.WriteLine(GetSoldProducts(dbContext)); // 06. Export Sold Product
            //Console.WriteLine(GetCategoriesByProductsCount(dbContext)); // 07. Export Categories By Products Count
            Console.WriteLine(GetUsersWithProducts(dbContext)); // 08. Export Users and Products
        }

        // 01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportUsersDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);

            ImportUsersDto[] dtos = (ImportUsersDto[])xmlSerializer.Deserialize(stringReader);

            ICollection<User> users = new List<User>();

            foreach (var user in dtos)
            {
                User u = new User()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Age = user.Age,
                };

                users.Add(u);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        // 02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Products");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProductsDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);

            ImportProductsDto[] dtos = (ImportProductsDto[])xmlSerializer.Deserialize(stringReader);

            ICollection<Product> products = new List<Product>();

            foreach (var product in dtos)
            {
                Product p = new Product()
                {
                    Name = product.Name,
                    Price = product.Price,
                    SellerId = product.SellerId,
                    BuyerId = product.BuyerId,
                };

                products.Add(p);
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        // 03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Categories");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoriesDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);

            ImportCategoriesDto[] dtos = (ImportCategoriesDto[])xmlSerializer.Deserialize(stringReader);

            ICollection<Category> categories = new List<Category>();

            foreach (var category in dtos)
            {
                if (string.IsNullOrEmpty(category.Name))
                {
                    continue;
                }

                Category c = new Category()
                {
                    Name = category.Name,
                };

                categories.Add(c);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        // 04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("CategoryProducts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CategoryProductDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);

            CategoryProductDto[] dtos = (CategoryProductDto[])xmlSerializer.Deserialize(stringReader);

            ICollection<CategoryProduct> categoryProd = new List<CategoryProduct>();

            var categoryIds = context.Categories.Select(x => x.Id).ToList();
            var productIds = context.Products.Select(x => x.Id).ToList();

            foreach (var catProd in dtos)
            {
                if (!categoryIds.Contains(catProd.CategoryId) || !productIds.Contains(catProd.ProductId))
                {
                    continue;
                }

                CategoryProduct cp = new CategoryProduct()
                {
                    ProductId = catProd.ProductId,
                    CategoryId = catProd.CategoryId
                };

                categoryProd.Add(cp);
            }

            context.CategoryProducts.AddRange(categoryProd);
            context.SaveChanges();

            return $"Successfully imported {categoryProd.Count}";
        }

        // 05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Products");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProductsInRangeDto[]), xmlRoot);

            StringBuilder sb = new StringBuilder();

            using StringWriter stringWriter = new StringWriter(sb);

            ProductsInRangeDto[] dtos = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Take(10)
                .Select(x => new ProductsInRangeDto()
                {
                    Name = x.Name,
                    Price = x.Price.ToString(),
                    Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName,
                })
                .ToArray();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            xmlSerializer.Serialize(stringWriter, dtos, namespaces);

            return sb.ToString().TrimEnd();
        }

        // 06. Export Sold Product
        public static string GetSoldProducts(ProductShopContext context)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserSoldProductsDto[]), xmlRoot);

            StringBuilder sb = new StringBuilder();

            using StringWriter stringWriter = new StringWriter(sb);

            UserSoldProductsDto[] dtos = context.Users
                .Where(x => x.ProductsSold.Any())
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .Select(x => new UserSoldProductsDto()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold
                    .Select(x => new SoldProductsDto()
                    {
                        Name = x.Name,
                        Price = x.Price.ToString()
                    })
                    .ToArray()
                })
                .ToArray();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            xmlSerializer.Serialize(stringWriter, dtos, namespaces);

            return sb.ToString().TrimEnd();
        }

        // 07. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Categories");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CategoriesByProductsCountDto[]), xmlRoot);

            StringBuilder sb = new StringBuilder();

            using StringWriter stringWriter = new StringWriter(sb);

            CategoriesByProductsCountDto[] dtos = context.Categories
                .OrderByDescending(x => x.CategoryProducts.Count())
                .ThenBy(x => x.CategoryProducts.Sum(y => y.Product.Price))
                .Select(x => new CategoriesByProductsCountDto()
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count().ToString(),
                    AveragePrice = x.CategoryProducts.Average(z => z.Product.Price).ToString(),
                    TotalRevenue = x.CategoryProducts.Sum(y => y.Product.Price).ToString()
                })
                .ToArray();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            xmlSerializer.Serialize(stringWriter, dtos, namespaces);

            return sb.ToString().TrimEnd();

        }

        // 08. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserSoldProductsDto[]), xmlRoot);

            StringBuilder sb = new StringBuilder();

            using StringWriter stringWriter = new StringWriter(sb);

            UserSoldProductsDto[] dtos = context.Users
                .Where(x => x.ProductsSold.Any())
                .OrderByDescending(x => x.ProductsSold.Count())
                .Select(x => new UserSoldProductsDto()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age.ToString(),
                    //SoldProducts =  new SoldProductsCountDto
                    //{
                    //    Count = x.ProductsSold.Count(),
                    //    Products = x.ProductsSold
                    //    .Select(z => new SoldProductsDto
                    //    {
                    //        Name = z.Name,
                    //        Price = z.Price.ToString()
                    //    }).ToArray()
                    //}
                    
                })
                .ToArray();

            MainDto outputDto = new MainDto()
            {
                Count = dtos.Count(),
                Users = dtos.Take(10).ToArray()
            };

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            xmlSerializer.Serialize(stringWriter, dtos, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}