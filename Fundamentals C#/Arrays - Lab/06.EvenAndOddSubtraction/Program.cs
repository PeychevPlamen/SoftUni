using System;
using System.Linq;

namespace _06.EvenAndOddSubtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int sumOddNums = 0;
            int sumEvenNums = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int currentNum = nums[i];

                if (currentNum % 2 == 0)
                {
                    sumEvenNums += currentNum;
                }
                else
                {
                    sumOddNums += currentNum;
                }
            }
            Console.WriteLine(sumEvenNums - sumOddNums);
        }
    }
}
