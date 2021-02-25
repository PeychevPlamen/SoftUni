using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse)
                                     .ToList();

            string[] commands = Console.ReadLine()
                                       .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (commands[0] != "end")
            {
                if (commands[0] == "Delete")
                {
                    int element = int.Parse(commands[1]);

                    input.RemoveAll(n => n == element);
                }
                else if (commands[0] == "Insert")
                {
                    int element = int.Parse(commands[1]);
                    int position = int.Parse(commands[2]);

                    input.Insert(position, element);
                }

                commands = Console.ReadLine()
                                  .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
