using System;

namespace _08._BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numKeg = int.Parse(Console.ReadLine());

            string biggestKeg = string.Empty;
            double currentKeg = 0;
            double bestKeg = 0;

            for (int i = 0; i < numKeg; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                currentKeg = Math.PI * (Math.Pow(radius, 2)) * height;

                if (bestKeg < currentKeg)
                {
                    bestKeg = currentKeg;
                    biggestKeg = model;
                }
            }
            Console.WriteLine(biggestKeg);
        }
    }
}
