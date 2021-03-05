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
