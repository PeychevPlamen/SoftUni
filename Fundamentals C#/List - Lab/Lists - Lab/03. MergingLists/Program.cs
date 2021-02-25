using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstNums = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToList();

            List<int> secondNums = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToList();

            List<int> resultList = new List<int>();

            for (int i = 0; i < Math.Max(firstNums.Count, secondNums.Count); i++)
            {
                if (firstNums.Count > i)
                {
                    resultList.Add(firstNums[i]);
                }
                if (secondNums.Count > i)
                {
                    resultList.Add(secondNums[i]);
                }
            }

            Console.WriteLine(string.Join(" ", resultList));
        }

    }
}
