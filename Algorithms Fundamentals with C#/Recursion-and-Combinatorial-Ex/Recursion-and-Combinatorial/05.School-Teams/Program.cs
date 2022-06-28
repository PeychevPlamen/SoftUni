using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.School_Teams
{
    public class Program
    {
        static void Main(string[] args)
        {
            var girls = Console.ReadLine().Split(", ");
            var girlsCombination = new string[3];
            var allGirlsCombs = new List<string[]>();

            GenCombs(0, 0, girls, girlsCombination, allGirlsCombs);

            var boys = Console.ReadLine().Split(", ");
            var boysCombination = new string[2];
            var allBoysCombs = new List<string[]>();

            GenCombs(0, 0, boys, boysCombination, allBoysCombs);

            PrintFinalOutput(allGirlsCombs, allBoysCombs);
        }

        private static void PrintFinalOutput(List<string[]> allGirlsCombs, List<string[]> allBoysCombs)
        {
            foreach (var girls in allGirlsCombs)
            {
                foreach (var boys in allBoysCombs)
                {
                    Console.WriteLine($"{string.Join(", ", girls)}, {string.Join(", ", boys)}");
                }
            }
        }

        private static void GenCombs(int idx, int start, string[] elements, string[] comb, List<string[]> combs)
        {
            if (idx >= comb.Length)
            {
                combs.Add(comb.ToArray());
                return;
            }

            for (int i = start; i < elements.Length; i++)
            {
                comb[idx] = elements[i];
                GenCombs(idx + 1, i + 1, elements, comb, combs);
            }
        }
    }
}
