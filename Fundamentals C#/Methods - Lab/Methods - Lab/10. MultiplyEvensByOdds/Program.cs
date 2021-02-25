using System;

namespace _10._MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            n = Math.Abs(n);

            Console.WriteLine(GetMultipleOfEvenAndOdds(n));
        }
        static int GetMultipleOfEvenAndOdds(int n)
        {
            return GetSumOfEvenDigits(n) * GetSumOfOddDigits(n);
        }
        static int GetSumOfEvenDigits(int n)
        {
            string evenDigits = n.ToString();
            int sum = 0;

            for (int i = 0; i < evenDigits.Length; i++)
            {
                int currentDigit = int.Parse(evenDigits[i].ToString());

                if (currentDigit % 2 == 0)
                {
                    sum += currentDigit;
                }
            }
            return sum;
        }
        static int GetSumOfOddDigits(int n)
        {
            string oddDigits = n.ToString();
            int sum = 0;

            for (int i = 0; i < oddDigits.Length; i++)
            {
                int currentDigit = int.Parse(oddDigits[i].ToString());

                if (currentDigit % 2 == 1)
                {
                    sum += currentDigit;
                }
            }
            return sum;
        }
        
    }
}
