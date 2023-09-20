using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int nLines = int.Parse(Console.ReadLine());

            SortedSet<string> elements = new SortedSet<string>();

            for (int i = 0; i < nLines; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in input)
                {
                    elements.Add(item);
                }
            }

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
