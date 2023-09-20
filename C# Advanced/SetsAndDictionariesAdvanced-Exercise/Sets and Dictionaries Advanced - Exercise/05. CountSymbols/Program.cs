using System;
using System.Collections.Generic;

namespace _05._CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] inputText = Console.ReadLine().ToCharArray();

            SortedDictionary<char, int> occurrences = new SortedDictionary<char, int>();

            foreach (var item in inputText)
            {
                if (!occurrences.ContainsKey(item))
                {
                    occurrences.Add(item, 0);
                }
                occurrences[item]++;
            }

            foreach (var item in occurrences)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
