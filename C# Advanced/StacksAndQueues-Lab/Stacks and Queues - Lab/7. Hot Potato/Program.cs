using System;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int n = int.Parse(Console.ReadLine());

            Queue<string> names = new Queue<string>(input);

            while (names.Count > 1)
            {
                string name = string.Empty;

                for (int i = 1; i < n; i++)
                {
                    name = names.Dequeue();
                    names.Enqueue(name);
                }

                name = names.Dequeue();

                Console.WriteLine($"Removed {name}");
            }

            Console.WriteLine($"Last is {names.Peek()}");
        }
    }
}
