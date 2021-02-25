using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace _01._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([>]{2})+(?<product>[A-Za-z]+)+[<]{2}(?<price>[0-9][.\]+[0-9]+)[!](?<quantity>\d+)\b";

            string input = Console.ReadLine();

            Regex regex = new Regex(pattern);

            List<string> products = new List<string>();
            double totalMoney = 0;

            while (input != "Purchase")
            {
                MatchCollection items = regex.Matches(input);

                foreach (Match item in items)
                {
                    string product = item.Groups["product"].Value;
                    double price = double.Parse(item.Groups["price"].Value);
                    int count = int.Parse(item.Groups["quantity"].Value);

                    totalMoney += price * count;

                    products.Add(product);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Total money spend: {totalMoney:f2}");

        }
    }
}
