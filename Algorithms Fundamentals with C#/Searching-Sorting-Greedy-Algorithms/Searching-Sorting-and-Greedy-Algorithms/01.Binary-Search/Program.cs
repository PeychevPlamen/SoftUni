using System;
using System.Linq;

namespace _01.Binary_Search
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .OrderBy(x => x)
                .ToArray();

            var key = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(input, key));
        }

        private static int BinarySearch(int[] input, int key)
        {
            var left = 0;
            var right = input.Length - 1;

            while (left <= right)
            {
                var midle = (left + right) / 2;

                var element = input[midle];

                if (element == key)
                {
                    return midle;
                }
                if (key > element)
                {
                    left = midle + 1;
                }
                else
                {
                    right = midle - 1;
                }

            }

            return -1;
        }
    }
}
