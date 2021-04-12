using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tasksLine = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] threadsLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int taskToKill = int.Parse(Console.ReadLine());

            Stack<int> tasks = new Stack<int>(tasksLine);

            Queue<int> threads = new Queue<int>(threadsLine);

            int currTask;
            int currThread;
            string output = string.Empty;

            for (int i = 0; i < tasks.Count; i++)
            {
                currTask = tasks.Peek();
                currThread = threads.Peek();

                if (taskToKill == currTask)
                {
                    output = $"Thread with value {currThread} killed task {taskToKill}";

                    break;
                }
                if (currTask <= currThread)
                {
                    tasks.Pop();
                    threads.Dequeue();
                    i--;
                }
                else
                {
                    threads.Dequeue();
                    i--;
                }
            }

            Console.WriteLine(output);
            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
