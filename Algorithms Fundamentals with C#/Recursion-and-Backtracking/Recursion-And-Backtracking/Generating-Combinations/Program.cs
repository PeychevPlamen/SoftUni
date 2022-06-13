using System;
using System.Linq;

namespace Generating_Combinations
{
    public class Program
    {
        static void Main()
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int k = int.Parse(Console.ReadLine());

            var vector = new int[k];

            Generate(nums, vector, 0, 0);
        }

        private static void Generate(int[] nums, int[] vector, int index, int border)
        {
            if (index == vector.Length)
            {
                Console.WriteLine((string.Join(' ', vector)));

            }
            else
            {
                for (int i = border; i < nums.Length; i++)
                {
                    vector[index] = nums[i];
                    Generate(nums, vector, index + 1, i + 1);
                }
            }
        }
    }
}
