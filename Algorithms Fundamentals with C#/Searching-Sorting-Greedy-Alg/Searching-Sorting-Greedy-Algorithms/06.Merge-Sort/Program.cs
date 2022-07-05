using System;
using System.Linq;

namespace _06.Merge_Sort
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();

            var result = MergerSort(input);

            Console.WriteLine(string.Join(" ", result));
        }

        private static int[] MergerSort(int[] input)
        {
            if (input.Length <= 1)
            {
                return input;
            }

            var left = input.Take(input.Length / 2).ToArray();
            var right = input.Skip(input.Length / 2).ToArray();

            return Merge(MergerSort(left), MergerSort(right));
        }

        private static int[] Merge(int[] left, int[] right)
        {
            var merge = new int[left.Length + right.Length];

            var mergeIdx = 0;
            var leftIdx = 0;
            var rightIdx = 0;

            while (leftIdx < left.Length && rightIdx < right.Length)
            {
                if (left[leftIdx] < right[rightIdx])
                {
                    merge[mergeIdx++] = left[leftIdx++];
                }
                else
                {
                    merge[mergeIdx++] = right[rightIdx++];
                }
            }

            for (int i = leftIdx; i < left.Length; i++)
            {
                merge[mergeIdx++] = left[i];
            }

            for (int i = rightIdx; i < right.Length; i++)
            {
                merge[mergeIdx++] = right[i];
            }

            return merge;
        }
    }
}
