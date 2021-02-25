using System;

namespace _05._SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            int num = 0;
            int firstIndex = 0;
            int secondIndex = 0;
            int sum = 0;
            string special = string.Empty;

            for (int i = 1; i <= input; i++)
            {
                num = i % 10;
                firstIndex = num;
                num = i / 10;
                secondIndex = num;
                sum = firstIndex + secondIndex;

                if (sum == 5 || sum == 7 || sum == 11)
                {
                    special = "True";
                }
                else
                {
                    special = "False";
                }
                Console.WriteLine($"{i} -> {special}");
            }
        }
    }
}
