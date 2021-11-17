using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            string inputUsersJSON = File.ReadAllText("../../../Datasets/users.json");
            string inputProductsJSON = File.ReadAllText("../../../Datasets/products.json");
            string inputCategoriesProductsJSON = File.ReadAllText("../../../Datasets/categories-products.json");
            string inputCategoriesJSON = File.ReadAllText("../../../Datasets/categories.json");


            //Console.WriteLine(ImportUsers(context, inputUsersJSON)); // 2. Import Users
            //Console.WriteLine(ImportProducts(context, inputProductsJSON)); // 3. Import Products
            //Console.WriteLine(ImportCategories(context, inputCategoriesJSON)); // 4. Import Categories
            //Console.WriteLine(ImportCategoryProducts(context, inputCategoriesProductsJSON)); // 5. Import Categories and Products
            //Console.WriteLine(GetProductsInRange(context)); // 05. Export Products In Range
            //Console.WriteLine(GetSoldProducts(context)); // 06. Export Successfully Sold Products
            // Console.WriteLine(GetCategoriesByProductsCount(context));
            Console.WriteLine(GetUsersWithProducts(context));
        }

        // Query 2. Import Users

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            IEnumerable<User> users = JsonConvert.DeserializeObject<IEnumerable<User>>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        // Query 3. Import Products

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IEnumerable<Product> products = JsonConvert.DeserializeObject<IEnumerable<Product>>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        // Query 4. Import Categories

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IEnumerable<Category> categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(inputJson)
                .Where(c => c.Name != null);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        // Query 5. Import Categories and Products

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            IEnumerable<CategoryProduct> catProducts = JsonConvert.DeserializeObject<IEnumerable<CategoryProduct>>(inputJson);

            context.CategoryProducts.AddRange(catProducts);
            context.SaveChanges();

            return $"Successfully imported {catProducts.Count()}";
        }

        // 05. Export Products In Range

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .ToArray();

            var productsToJSON = JsonConvert.SerializeObject(products, Formatting.Indented);

            return productsToJSON;
        }

        // Query 6. Export Successfully Sold Products

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any(ps => ps.Buyer != null))
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold
                    .Select(ps => new
                    {
                        name = ps.Name,
                        price = ps.Price,
                        buyerFirstName = ps.Buyer.FirstName,
                        buyerLastName = ps.Buyer.LastName
                    })
                    .ToArray()
                })
                .ToArray();

            var usersToJson = JsonConvert.SerializeObject(users, Formatting.Indented);

            return usersToJson;
        }

        // 07. Export Categories By Products Count

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count,
                    averagePrice = $"{c.CategoryProducts.Average(x => x.Product.Price):f2}",
                    totalRevenue = $"{c.CategoryProducts.Sum(x => x.Product.Price)}"
                })
                .ToArray();

            var catToJson = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return catToJson;
        }

        // 08. Export Users and Products

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                 .Include(x => x.ProductsSold)
                 .ToList()
                 .Where(u => u.ProductsSold.Any(b => b.BuyerId != null))
                 .Select(u => new
                 {
                     firstName = u.FirstName,
                     lastName = u.LastName,
                     age = u.Age,
                     soldProducts = new
                     {
                         count = u.ProductsSold.Where(b => b.BuyerId != null).Count(),
                         products = u.ProductsSold.Where(b => b.BuyerId != null)
                         .Select(p => new
                         {
                             name = p.Name,
                             price = p.Price,
                         })
                     }
                 })
                 .OrderByDescending(x => x.soldProducts.products.Count());

            var usersCount = new
            {
                usersCount = users.Count(),
                users = users
            };

            var jsOptions = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            var resultJson = JsonConvert.SerializeObject(usersCount, Formatting.Indented, jsOptions);

            return resultJson;
        }
    }
}