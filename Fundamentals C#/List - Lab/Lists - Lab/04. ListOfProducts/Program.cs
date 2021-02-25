using System;
using System.Collections.Generic;

namespace _04._ListOfProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            List<string> products = new List<string>();

            for (int i = 0; i < num; i++)
            {
                string currProduct = Console.ReadLine();
                products.Add(currProduct);
            }
            products.Sort();

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{products[i]}");
            }
        }
    }
}
