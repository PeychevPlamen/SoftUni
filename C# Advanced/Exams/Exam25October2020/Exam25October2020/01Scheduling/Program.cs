using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] taskInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] threadsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int taskToKill = int.Parse(Console.ReadLine());

            Stack<int> tasks = new Stack<int>(taskInput);
            Queue<int> threads = new Queue<int>(threadsInput);

            while (true)
            {
                if (tasks.Peek() == taskToKill)
                {
                    Console.WriteLine($"Thread with value {threads.Peek()} killed task {taskToKill}");
                    Console.WriteLine(string.Join(" ", threads));

                    break;
                }
                if (threads.Peek() >= tasks.Peek())
                {
                    threads.Dequeue();
                    tasks.Pop();
                }
                else
                {
                    threads.Dequeue();
                }
            }

        }
    }
}
