﻿using System;
using System.Linq;

namespace _07._EqualArrays
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

            for (int i = 0; i < arr1.Length; i++)
            {
                int sumArr = arr1[i];

                if (arr1[i] != arr2[i])
                {
                    isTrue = false;
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
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
            
        }
    }
}
