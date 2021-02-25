using System;
using System.Linq;

namespace _09._KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int nums = int.Parse(Console.ReadLine());

            string input = string.Empty;

            int bestLenght = 1;
            int bestStartIndex = 0;
            int bestSequenceSum = 0;
            int bestSequenceIndex = 0;
            int[] bestSequence = new int[nums];

            int sequenceCounter = 0;

            // 1!0!1!1!0
            // 0!1!1!0!0

            while ((input = Console.ReadLine()) != "Clone them!")
            {
                int[] dnaSample = input
                    .Split('!', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                sequenceCounter++;
                int lenght = 1;
                int bestCurrentLenght = 1;
                int startIndex = 0;
                int currentSequenceSum = 0;

                for (int i = 0; i < dnaSample.Length - 1; i++)
                {
                    if (dnaSample[i] == dnaSample[i + 1])
                    {
                        lenght++;
                    }
                    else
                    {
                        lenght = 1;
                    }
                    if (lenght > bestCurrentLenght)
                    {
                        bestCurrentLenght = lenght;
                        startIndex = i;
                    }
                    currentSequenceSum += dnaSample[i];
                }
                currentSequenceSum += dnaSample[nums - 1];

                if (bestCurrentLenght > bestLenght)
                {
                    bestLenght = bestCurrentLenght;
                    bestStartIndex = startIndex;
                    bestSequenceSum = currentSequenceSum;
                    bestSequenceIndex = sequenceCounter;
                    bestSequence = dnaSample.ToArray();
                }
                else if (bestCurrentLenght == bestLenght)
                {
                    if (startIndex < bestStartIndex)
                    {
                        bestLenght = bestCurrentLenght;
                        bestStartIndex = startIndex;
                        bestSequenceSum = currentSequenceSum;
                        bestSequenceIndex = sequenceCounter;
                        bestSequence = dnaSample.ToArray();
                    }
                    else if (startIndex == bestStartIndex)
                    {
                        if (currentSequenceSum > bestSequenceSum)
                        {
                            bestLenght = bestCurrentLenght;
                            bestStartIndex = startIndex;
                            bestSequenceSum = currentSequenceSum;
                            bestSequenceIndex = sequenceCounter;
                            bestSequence = dnaSample.ToArray();
                        }
                    }
                }
            }

            Console.WriteLine($"Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}.");
            Console.WriteLine(String.Join(' ', bestSequence));
        }
    }
}
