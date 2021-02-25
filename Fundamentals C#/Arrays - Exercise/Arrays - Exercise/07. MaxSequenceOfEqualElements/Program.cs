using System;
using System.Linq;

namespace _07._MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            // 2 1 1 2 3 3 2 2 2 1

            int maxLenght = 0;
            int lenght = 1;

            int startIndex = 0;
            int bestStartIndex = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1])
                {
                    lenght++;
                }
                else
                {
                    lenght = 1;
                    startIndex = i;
                }
                if (lenght > maxLenght)
                {
                    maxLenght = lenght;
                    bestStartIndex = startIndex;
                }
            }
            for (int i = bestStartIndex; i < bestStartIndex + maxLenght; i++)
            {
                Console.Write(nums[i] + " ");
            }
        }
    }
}
