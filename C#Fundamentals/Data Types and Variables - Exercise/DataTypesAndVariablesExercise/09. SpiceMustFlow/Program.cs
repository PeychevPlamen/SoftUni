using System;

namespace _09._SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());

            int counter = 0;
            int currentYield = 0;

            if (startingYield < 100)
            {
                Console.WriteLine(counter);
                Console.WriteLine(currentYield);
            }
            while (startingYield >= 100)
            {
                counter++;
                currentYield += startingYield - 26;
                startingYield -= 10;

            }
            if (startingYield < 100 && currentYield > 0)
            {
                currentYield -= 26;
                Console.WriteLine(counter);
                Console.WriteLine(currentYield);
            }

        }
    }
}
