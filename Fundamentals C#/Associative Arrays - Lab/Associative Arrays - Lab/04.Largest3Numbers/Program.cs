using System;
using System.Linq;

namespace _04.Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToArray();

            int[] sorted = numbers.OrderByDescending(n => n)
                                  .ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {

                if (i < 3)
                {
                    Console.Write($"{sorted[i]} ");
                }
                else
                {
                    break;
                }
                
            }
        }
    }
}
