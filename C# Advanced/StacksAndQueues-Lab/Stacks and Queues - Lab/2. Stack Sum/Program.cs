using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(nums);

            string commands = Console.ReadLine().ToLower();

            while (commands != "end")
            {
                string[] cmd = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string currCmd = cmd[0];

                if (currCmd == "add")
                {
                    int firstNum = int.Parse(cmd[1]);
                    int secondNum = int.Parse(cmd[2]);

                    stack.Push(firstNum);
                    stack.Push(secondNum);
                }
                else
                {
                    int n = int.Parse(cmd[1]);

                    for (int i = 0; i < n; i++)
                    {
                        if (n > stack.Count) break;

                        stack.Pop();
                    }
                }

                commands = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
