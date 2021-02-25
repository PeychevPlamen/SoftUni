using System;

namespace _10._PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustion = int.Parse(Console.ReadLine());

            int counter = 0;
            double tempPower = pokePower * 0.5;
            
            while (distance <= pokePower)
            {
                counter++;
                pokePower -= distance;

                if (pokePower == tempPower && exhaustion != 0)
                {
                    pokePower /= exhaustion;
                }
            }

            Console.WriteLine(pokePower);
            Console.WriteLine(counter);
        }
    }
}
