using System;
using System.Linq;

namespace Insertion_Sort
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();

            InsertionSort(input);

            Console.WriteLine(string.Join(" ", input));
        }

        private static void InsertionSort(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                var j = i;

                while (j > 0 && input[j - 1] > input[j])
                {
                    Swap(input, j - 1, j);
                    j--;
                }
            }
        }
        private static void Swap(int[] input, int first, int second)
        {
            var temp = input[first];
            input[first] = input[second];
            input[second] = temp;
        }
    }
}
