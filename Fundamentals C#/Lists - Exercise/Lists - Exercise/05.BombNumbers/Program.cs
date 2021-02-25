using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToList();

            int[] actionNums = Console.ReadLine()
                                      .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToArray();

            int bomb = actionNums[0];
            int area = actionNums[1];

            for (int i = 0; i < nums.Count; i++)
            {
                int currentNum = nums[i];

                if (currentNum == bomb)
                {
                    int startIndex = i - area;
                    int endIndex = i + area;

                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    if (endIndex > nums.Count - 1)
                    {
                        endIndex = nums.Count - 1;
                    }

                    int rangeToRemove = endIndex - startIndex + 1;
                    nums.RemoveRange(startIndex, rangeToRemove);

                    i = startIndex - 1;
                }
            }

            Console.WriteLine(nums.Sum());
        }
    }
}
