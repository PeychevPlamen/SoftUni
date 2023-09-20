using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();

            while (input != "Revision")
            {
                string[] tokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string shop = tokens[0];
                string product = tokens[1];
                double price = double.Parse(tokens[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }
                shops[shop].Add(product, price);

                input = Console.ReadLine();
            }

            foreach (var shop in shops.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }

        }
    }
}
