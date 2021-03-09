using System;
using System.Collections.Generic;

namespace _03.ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> people;
            Dictionary<string, Product> products;

            try
            {
                people = ReadPeople();
                products = ReadProduct();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputCmd = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string personName = inputCmd[0];
                string productName = inputCmd[1];

                Person person = people[personName];
                Product product = products[productName];
                try
                {
                    person.AddProduct(product);

                    Console.WriteLine($"{personName} bought {productName}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    
                }
                

                input = Console.ReadLine();
            }

            foreach (var person in people.Values)
            {
                Console.WriteLine(person);
            }

            //
            //  Another solution with List<> of this task
            //

            //  List<Person> people = new List<Person>();

            //  List<Product> products = new List<Product>();

            //  try
            //  {
            //    people = Console.ReadLine()
            //                .Split(';', StringSplitOptions.RemoveEmptyEntries)
            //                .Select(t => t.Split('='))
            //                .Select(t => new Person(t[0], decimal.Parse(t[1])))
            //                .ToList();


            //    products = Console.ReadLine()
            //              .Split(';', StringSplitOptions.RemoveEmptyEntries)
            //              .Select(t => t.Split('='))
            //              .Select(t => new Product(t[0], decimal.Parse(t[1])))
            //              .ToList();
            //  }
            //  catch (ArgumentException ex)
            //  {

            //    Console.WriteLine(ex.Message);
            //    return;
            //  }


            //  string input = Console.ReadLine();

            //  while (input != "END")
            //  {

            //    string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            //    Person customer = people.First(p => p.Name == tokens[0]);
            //    Product purchase = products.First(products => products.Name == tokens[1]);

            //    try
            //    {
            //        customer.AddProduct(purchase);

            //        Console.WriteLine($"{customer.Name} bought {purchase.Name}");

            //    }
            //    catch (ArgumentException ex)
            //    {

            //        Console.WriteLine(ex.Message);

            //    }

            //    input = Console.ReadLine();
            //  }

            //  foreach (var person in people)
            //  {
            //    Console.WriteLine(person);
            //  }


        }

        private static Dictionary<string, Product> ReadProduct()
        {
            Dictionary<string, Product> result = new Dictionary<string, Product>();

            string[] parts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                string[] productData = part.Split("=", StringSplitOptions.RemoveEmptyEntries);

                string productName = productData[0];
                decimal productCost = decimal.Parse(productData[1]);

                result[productName] = new Product(productName, productCost);
            }
            return result;
        }

        private static Dictionary<string, Person> ReadPeople()
        {
            Dictionary<string, Person> result = new Dictionary<string, Person>();

            string[] parts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                string[] personData = part.Split("=", StringSplitOptions.RemoveEmptyEntries);

                string name = personData[0];
                decimal money = decimal.Parse(personData[1]);

                result[name] = new Person(name, money);

            }

            return result;
        }

    }
}
