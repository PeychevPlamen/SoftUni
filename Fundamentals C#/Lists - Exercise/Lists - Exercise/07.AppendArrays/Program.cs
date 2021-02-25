using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> arr = Console.ReadLine()
                                  .Split("|", StringSplitOptions.RemoveEmptyEntries)
                                  .ToList();

            arr.Reverse();

            List<string> result = new List<string>();

            foreach (var currentItem in arr)
            {
                string[] numbers = currentItem
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                foreach (var numbersToAdd in numbers)
                {
                    result.Add(numbersToAdd);
                }
            }
            Console.WriteLine(string.Join(" " , result));
        }
    }
}
