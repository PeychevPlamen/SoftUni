using System;
using System.Linq;

namespace _09.KaminoFactory2
{
    class Program
    {
        static void Main(string[] args)
        {
            int sequenceLeght = int.Parse(Console.ReadLine());

            string input = string.Empty;

            int sequenceCounter = 0;


            // 1!0!1!1!0

            while ((input = Console.ReadLine()) != "Clone them!")
            {
                int[] dnaSequence = input
                        .Split('!', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                int startIndex = 0;
                int bestLenght = 1;
                int lenght = 1;
                int sequenceSum = 0;

                sequenceCounter++;

                for (int i = 0; i < dnaSequence.Length - 1; i++)
                {
                    if (dnaSequence[i] == dnaSequence[i + 1])
                    {
                        lenght++;
                    }
                    else
                    {
                        lenght = 1;
                    }
                    if (lenght > bestLenght)
                    {
                        bestLenght = lenght;
                        startIndex = i;
                    }
                    sequenceSum += dnaSequence[i];
                }


            }
        }
    }
}
