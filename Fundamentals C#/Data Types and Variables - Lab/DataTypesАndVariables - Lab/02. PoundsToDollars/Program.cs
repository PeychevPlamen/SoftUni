using System;

namespace _02._PoundsToDollars
{
    class Program
    {
        static void Main(string[] args)
        {
            double pounds = double.Parse(Console.ReadLine());

            decimal usd = (decimal)(pounds * 1.31);

            Console.WriteLine($"{usd:f3}");
        }
    }
}
