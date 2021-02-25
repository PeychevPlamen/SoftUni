using System;
using System.Collections.Generic;

namespace _03.HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int numCommands = int.Parse(Console.ReadLine());
            List<string> names = new List<string>();

            for (int i = 0; i < numCommands; i++)
            {
                string[] input = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input.Length > 3)
                {
                    if (names.Contains(input[0]))
                    {
                        names.Remove(input[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{input[0]} is not in the list!");
                    }
                }
                else
                {
                    if (names.Contains(input[0]))
                    {
                        Console.WriteLine($"{input[0]} is already in the list!");
                    }
                    else
                    {
                        names.Add(input[0]);
                    }
                }
            }
            Console.WriteLine(string.Join("\n" , names));
        }
    }
}
