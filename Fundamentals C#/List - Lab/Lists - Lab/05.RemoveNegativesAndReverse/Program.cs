using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.RemoveNegativesAndReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> nums = Console.ReadLine()
                                       .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                       .Select(double.Parse)
                                       .ToList();

            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] < 0)
                {
                    nums.Remove(nums[i]);
                    i -= 1;
                }
            }
            if (nums.Count <= 0)
            {
                Console.WriteLine("empty");
            }
            nums.Reverse();

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
