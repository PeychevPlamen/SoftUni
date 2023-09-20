using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] setsSize = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstSet = setsSize[0];
            int secondSet = setsSize[1];

            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();

            for (int i = 0; i < firstSet; i++)
            {
                first.Add(int.Parse(Console.ReadLine()));
            }
            for (int j = 0; j < secondSet; j++)
            {
                second.Add(int.Parse(Console.ReadLine()));
            }

            //first.IntersectWith(second);
            //Console.WriteLine(string.Join(" ", first));

            HashSet<int> output = new HashSet<int>();
            output = first.Intersect(second).ToHashSet();

            Console.WriteLine(string.Join(" ", output));
        }
    }
}
