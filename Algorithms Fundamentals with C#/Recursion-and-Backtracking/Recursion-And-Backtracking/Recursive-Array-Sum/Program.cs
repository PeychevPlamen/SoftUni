using System;
using System.Linq;

namespace Recursive_Array_Sum
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                                 .Split(' ')
                                 .Select(int.Parse)
                                 .ToArray();

            Console.WriteLine(SumRecursively(numbers, 0));

        }

        private static int SumRecursively(int[] numbers, int v)
        {
            if (v == numbers.Length - 1)
            {
                return numbers[v];
            }

            return numbers[v] + SumRecursively(numbers, v + 1);
        }
    }
}
