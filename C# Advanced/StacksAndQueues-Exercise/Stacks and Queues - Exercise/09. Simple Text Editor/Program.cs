using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var text = new StringBuilder();

            Stack<string> stack = new Stack<string>();
            stack.Push(text.ToString());

            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine()
                                           .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string currCmd = commands[0];

                if (currCmd == "1")
                {
                    string currText = commands[1];
                    text.Append(currText);
                    stack.Push(text.ToString());
                }
                else if (currCmd == "2")
                {
                    int count = int.Parse(commands[1]);
                    text.Remove(text.Length - count, count);
                    stack.Push(text.ToString());
                }
                else if (currCmd == "3")
                {
                    int index = int.Parse(commands[1]);
                    Console.WriteLine(text[index - 1]);
                }
                else if (currCmd == "4")
                {
                    stack.Pop();
                    text = new StringBuilder();
                    text.Append(stack.Peek());
                }
            }
        }
    }
}
