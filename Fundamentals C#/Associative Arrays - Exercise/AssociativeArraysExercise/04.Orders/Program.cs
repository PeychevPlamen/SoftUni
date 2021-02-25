using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string cmd = Console.ReadLine();

            Dictionary<string, List<double>> output = new Dictionary<string, List<double>>();

            while (cmd != "buy")
            {
                string[] tokens = cmd.Split();
                string product = tokens[0];
                double price = double.Parse(tokens[1]);
                int quantity = int.Parse(tokens[2]);

                List<double> priceAndQuantity = new List<double> { price, quantity };

                if (output.ContainsKey(product) == false)
                {
                    output.Add(product, priceAndQuantity);
                }
                else
                {
                    output[product][0] = price;
                    output[product][1] = quantity + output[product][1];
                }

                cmd = Console.ReadLine();
            }
            foreach (var item in output)
            {
                double totalPrice = item.Value[0] * item.Value[1];
                Console.WriteLine($"{item.Key} -> {totalPrice:f2}");
            }
        }
    }
}
