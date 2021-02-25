using System;
using System.Linq;

namespace _07._EqualArraysVer2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] arr2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int totalSum = 0;
            bool isTrue = false;
            int numInArrPosition = 0;

            for (int i = 0; i < arr1.Length; i++)
            {
                int sumArr = arr1[i];

                if (arr1[i] != arr2[i])
                {
                    isTrue = false;
                    numInArrPosition = i;
                    break;
                }
                else
                {
                    totalSum += sumArr;
                    isTrue = true;
                }
            }
            if (isTrue)
            {
                Console.WriteLine($"Arrays are identical. Sum: {totalSum}");
            }
            else
            {
                Console.WriteLine($"Arrays are not identical. Found difference at {numInArrPosition} index");
            }

        }
    }
}
