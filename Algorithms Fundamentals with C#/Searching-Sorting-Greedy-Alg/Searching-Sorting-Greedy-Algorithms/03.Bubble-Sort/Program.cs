using System;
using System.Linq;

namespace _03.Bubble_Sort
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            BubbleSort(input);

            Console.WriteLine(string.Join(" ", input));
        }

        private static void BubbleSort(int[] input)
        {
            var count = 0;

            for (int i = 0; i < input.Length; i++)
            {
                var min = i;
               
                for (int j = i + 1; j < input.Length - count; j++)
                {
                    if (input[j] < input[min])
                    {
                        min = j;
                    }
                    if (j == input.Length - count)
                    {
                        count++;
                    }
                    else
                    {
                        continue;
                    }
                }

                Swap(input, i, min);
            }
        }
        private static void Swap(int[] input, int first, int second)
        {
            var temp = input[first];
            input[first] = input[second];
            input[second] = temp;
        }
    }
}
