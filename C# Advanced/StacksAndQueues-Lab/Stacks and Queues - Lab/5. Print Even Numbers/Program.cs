using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();

            Queue<int> nums = new Queue<int>(input);

            List<int> output = new List<int>();

            while (nums.Count > 0)
            {
                int currNum = nums.Dequeue();

                if (currNum % 2 == 0)
                {
                    output.Add(currNum);
                }
            }

            Console.WriteLine(string.Join(", ", output));
        }
    }
}
