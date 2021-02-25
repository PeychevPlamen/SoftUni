using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToList();
            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] tokens = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int numbersToDo = 0;

                if (tokens[0] == "Add")
                {
                    numbersToDo = int.Parse(tokens[1]);
                    input.Add(numbersToDo);
                }
                else if (tokens[0] == "Remove")
                {
                    numbersToDo = int.Parse(tokens[1]);
                    input.Remove(numbersToDo);
                }
                else if (tokens[0] == "RemoveAt")
                {
                    numbersToDo = int.Parse(tokens[1]);
                    input.RemoveAt(numbersToDo);
                }
                else if (tokens[0] == "Insert")
                {
                    numbersToDo = int.Parse(tokens[1]);
                    int indexToInsert = int.Parse(tokens[2]);
                    input.Insert(indexToInsert, numbersToDo);
                }
            }
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
