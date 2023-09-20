using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            List<int> numbers = new List<int>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                                          .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int currCmd = int.Parse(command[0]);

                if (currCmd == 1)
                {
                    int numberToPush = int.Parse(command[1]);

                    stack.Push(numberToPush);
                }
                else if (currCmd == 2)
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
                else if (currCmd == 3)
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Max());
                    }
                }
                else if (currCmd == 4)
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }
            while (stack.Count != 0)
            {
                numbers.Add(stack.Pop());
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
