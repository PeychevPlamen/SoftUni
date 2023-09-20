using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = input[0];
            int dequeueElements = input[1];
            int toLookFor = input[2];

            int minNum = int.MaxValue;

            Queue<int> queue = new Queue<int>(numbers);

            for (int i = 0; i < dequeueElements; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(toLookFor))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Count < 1)
                {
                    minNum = 0;
                }
                else
                {
                    minNum = queue.Min();
                }

                Console.WriteLine($"{minNum}");
            }
        }
    }
}
