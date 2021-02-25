using System;

namespace _01._ConvertMetersТoKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            double distance = int.Parse(Console.ReadLine());

            decimal km = (decimal)distance / 1000;

            Console.WriteLine($"{km:f2}");

        }
    }
}
