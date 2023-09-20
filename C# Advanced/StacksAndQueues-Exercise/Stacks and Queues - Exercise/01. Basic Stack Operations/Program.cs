using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();

            int n = input[0];
            int toPop = input[1];
            int lookFor = input[2];

            int smallestNum = 0;

            int[] numbers = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

            Stack<int> stack = new Stack<int>(numbers);

            for (int i = 0; i < toPop; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(lookFor))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count < 1)
                {
                    smallestNum = 0;
                }
                else
                {
                    smallestNum = stack.Min();
                }
                
                Console.WriteLine(smallestNum);
            }

        }
    }
}
