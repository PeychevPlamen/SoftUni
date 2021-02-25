using System;

namespace _01._Sign_of_Integer_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            CheckTheSignOfInteger(num);

        }

        private static void CheckTheSignOfInteger(int num)
        {
            string sign = string.Empty;

            if (num > 0)
            {
                sign = "positive";
            }
            else if (num < 0)
            {
                sign = "negative";
            }
            else
            {
                sign = "zero";
            }

            Console.WriteLine($"The number {num} is {sign}.");
        }
    }
}
