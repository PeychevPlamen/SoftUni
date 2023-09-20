using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Stack<string> stack = new Stack<string>(input.Reverse());

            int firstNum = 0;
            int secondNum = 0;
            string sign = string.Empty;
            int sum = 0;

            while (stack.Count != 1)
            {
                firstNum = int.Parse(stack.Pop());
                sign = stack.Pop();
                secondNum = int.Parse(stack.Pop());

                if (sign == "+")
                {
                    sum = firstNum + secondNum;
                }
                else
                {
                    sum = firstNum - secondNum;
                }

                stack.Push(sum.ToString());

            }
            Console.WriteLine(sum);
        }
    }
}
