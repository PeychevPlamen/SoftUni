using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SumAdjacentEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> num = Console.ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(double.Parse)
                                .ToList();

            for (int i = 0; i < num.Count - 1; i++)
            {
                if (num[i] == num[i + 1])
                {
                    num[i] += num[i + 1];
                    num.RemoveAt(i + 1);
                    i = -1;
                }
            }
            Console.WriteLine(string.Join(" ", num));
        }
    }
}
