using System;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagonsCount = int.Parse(Console.ReadLine());

            int[] wagons = new int[wagonsCount];
            int sum = 0;

            for (int i = 0; i < wagonsCount; i++)
            {
                wagons[i] = int.Parse(Console.ReadLine());
                sum += wagons[i];
            }
            Console.WriteLine(String.Join(' ', wagons));
            Console.WriteLine(sum);
        }
    }
}
