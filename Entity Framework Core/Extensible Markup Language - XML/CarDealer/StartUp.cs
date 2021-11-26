using CarDealer.Data;
using CarDealer.Dto.Export;
using CarDealer.Dto.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var dbContext = new CarDealerContext();

            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            var inputCarsXml = File.ReadAllText("../../../Datasets/cars.xml");
            var inputCustomersXml = File.ReadAllText("../../../Datasets/customers.xml");
            var inputPartsXml = File.ReadAllText("../../../Datasets/parts.xml");
            var inputSalesXml = File.ReadAllText("../../../Datasets/sales.xml");
            var inputSuppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");

            //Console.WriteLine(ImportSuppliers(dbContext, inputSuppliersXml)); // 09.Import Suppliers
            //Console.WriteLine(ImportParts(dbContext, inputPartsXml));  // 10. Import Parts
            //Console.WriteLine(ImportCars(dbContext, inputCarsXml));  //  11. Import Cars
            //Console.WriteLine(ImportCustomers(dbContext, inputCustomersXml));  // 12. Import Customers
            //Console.WriteLine(ImportSales(dbContext, inputSalesXml));  // 13. Import Sales
            Console.WriteLine(GetCarsWithDistance(dbContext));  // 14. Export Cars With Distance
        }


        // 09.Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Suppliers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SuppliersDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);

            SuppliersDto[] dtos = (SuppliersDto[])xmlSerializer.Deserialize(stringReader);

            ICollection<Supplier> suppliers = new List<Supplier>();

            foreach (var supplier in dtos)
            {
                var sup = new Supplier()
                {
                    Name = supplier.Name,
                    IsImporter = supplier.IsImporter
                };

                suppliers.Add(sup);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}";
        }

        // 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Parts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PartsDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);

            PartsDto[] dtos = (PartsDto[])xmlSerializer.Deserialize(stringReader);

            ICollection<Part> parts = new List<Part>();

            var supplierId = context.Suppliers.Select(x => x.Id).ToList();

            foreach (var part in dtos)
            {
                if (!supplierId.Contains(part.SupplierId))
                {
                    continue;
                }

                var p = new Part()
                {
                    Name = part.Name,
                    Price = part.Price,
                    Quantity = part.Quantity,
                    SupplierId = part.SupplierId,
                };

                parts.Add(p);
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        // 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarsDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);

            CarsDto[] dtos = (CarsDto[])xmlSerializer.Deserialize(stringReader);

            var cars = new List<Car>();
            var partCars = new List<PartCar>();

            foreach (var currCar in dtos)
            {
                var car = new Car()
                {
                    Make = currCar.Make,
                    Model = currCar.Model,
                    TravelledDistance = currCar.TraveledDistance
                };

                var distinctPart = currCar
                    .Parts
                    .Where(pc => context.Parts.Any(x => x.Id == pc.Id))
                    .Select(pc => pc.Id)
                    .Distinct();

                foreach (var part in distinctPart)
                {
                    PartCar partcar = new PartCar
                    {
                        PartId = part,
                        Car = car,
                    };

                    partCars.Add(partcar);
                }

                cars.Add(car);
            }

            context.PartCars.AddRange(partCars);
            context.Cars.AddRange(cars);
            context.SaveChanges();
            return $"Successfully imported {cars.Count()}";
        }

        // 12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Customers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CustomersDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);

            CustomersDto[] dtos = (CustomersDto[])xmlSerializer.Deserialize(stringReader);

            ICollection<Customer> customers = new List<Customer>();

            foreach (var customer in dtos)
            {
                var c = new Customer()
                {
                    Name = customer.Name,
                    BirthDate = customer.BirthDate,
                    IsYoungDriver = customer.IsYoungDriver
                };

                customers.Add(c);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        // 13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Sales");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SalesDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);

            SalesDto[] dtos = (SalesDto[])xmlSerializer.Deserialize(stringReader);

            ICollection<Sale> sales = new List<Sale>();

            var carId = context.Cars.Select(x => x.Id).ToList();

            foreach (var sale in dtos)
            {
                if (!carId.Contains(sale.CarId))
                {
                    continue;
                }

                var s = new Sale()
                {
                    CarId = sale.CarId,
                    CustomerId = sale.CustomerId,
                    Discount = sale.Discount
                };

                sales.Add(s);
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}";
        }

        // 14. Export Cars With Distance

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarsWithDistanceExportDto[]), xmlRoot);

            StringBuilder sb = new StringBuilder();

            using StringWriter stringWriter = new StringWriter(sb);

            var cars = context.Cars
                .Where(x => x.TravelledDistance > 2000000)
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .Select(x => new CarsWithDistanceExportDto()
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .ToArray();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            xmlSerializer.Serialize(stringWriter, cars, namespaces);

            return sb.ToString().TrimEnd();

        }
    }
}