﻿using System;

namespace _06._StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int number = input;

            int currentNum = 0;
            int factorialSum = 0;

            while (number != 0)
            {
                currentNum = number % 10;
                number /= 10;

                int factorial = 1;

                for (int i = 1; i <= currentNum; i++)
                {
                    factorial *= i;
                }

                factorialSum += factorial;
                                
            }
            if (factorialSum == input)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
