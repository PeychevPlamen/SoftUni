using CarDealer.Data;
using CarDealer.Dto.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var dbContext = new CarDealerContext();

            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            var inputCarsXml = File.ReadAllText("../../../Datasets/cars.xml");
            var inputCustomersXml = File.ReadAllText("../../../Datasets/customers.xml");
            var inputPartsXml = File.ReadAllText("../../../Datasets/parts.xml");
            var inputSalesXml = File.ReadAllText("../../../Datasets/sales.xml");
            var inputSuppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");

            //Console.WriteLine(ImportSuppliers(dbContext, inputSuppliersXml)); // 09.Import Suppliers
            //Console.WriteLine(ImportParts(dbContext, inputPartsXml));  // 10. Import Parts
            Console.WriteLine(ImportCars(dbContext, inputCarsXml));  //  11. Import Cars
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
    }
}