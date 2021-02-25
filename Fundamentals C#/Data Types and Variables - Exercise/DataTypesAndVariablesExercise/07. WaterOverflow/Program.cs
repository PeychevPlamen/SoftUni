using System;

namespace _07._WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int tankCapacity = 255;
            int totalWater = 0;

            for (int i = 0; i < lines; i++)
            {
                int waterPour = int.Parse(Console.ReadLine());

                if (waterPour <= tankCapacity)
                {
                    tankCapacity -= waterPour;
                    totalWater += waterPour;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }

            Console.WriteLine(totalWater);
        }
    }
}
