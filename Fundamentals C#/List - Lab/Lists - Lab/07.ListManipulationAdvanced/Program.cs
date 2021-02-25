using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToList();

            string[] tokens =Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            bool isChange = false;

            while (tokens[0] != "end")
            {
                                
                int numbersToDo = 0;

                if (tokens[0] == "Add")
                {
                    isChange = true;
                    numbersToDo = int.Parse(tokens[1]);
                    input.Add(numbersToDo);
                    
                }
                else if (tokens[0] == "Remove")
                {
                    isChange = true;
                    isChange = true;
                    numbersToDo = int.Parse(tokens[1]);
                    input.Remove(numbersToDo);
                    
                }
                else if (tokens[0] == "RemoveAt")
                {
                    isChange = true;
                    numbersToDo = int.Parse(tokens[1]);
                    input.RemoveAt(numbersToDo);
                    
                }
                else if (tokens[0] == "Insert")
                {
                    isChange = true;
                    numbersToDo = int.Parse(tokens[1]);
                    int indexToInsert = int.Parse(tokens[2]);
                    input.Insert(indexToInsert, numbersToDo);
                    
                }
                else if (tokens[0] == "Contains")
                {
                    numbersToDo = int.Parse(tokens[1]);

                    if (!input.Contains(numbersToDo))
                    {
                        Console.WriteLine("No such number");
                    }
                    else
                    {
                        Console.WriteLine("Yes");
                    }
                }
                else if (tokens[0] == "PrintEven")
                {
                    List<int> evenList = new List<int>();

                    for (int i = 0; i < input.Count; i++)
                    {
                        if (input[i] % 2 == 0)
                        {
                            evenList.Add(input[i]);
                        }
                    }
                    Console.WriteLine(string.Join(" ", evenList));
                }
                else if (tokens[0] == "PrintOdd")
                {
                    List<int> oddList = new List<int>();

                    for (int i = 0; i < input.Count; i++)
                    {
                        if (input[i] % 2 == 1)
                        {
                            oddList.Add(input[i]);
                        }
                    }
                    Console.WriteLine(string.Join(" ", oddList));
                }
                else if (tokens[0] == "GetSum")
                {
                    Console.WriteLine(input.Sum());
                }
                else if (tokens[0] == "Filter")
                {
                    if (tokens[1] == ">=")
                    {
                        numbersToDo = int.Parse(tokens[2]);
                        List<int> filterList = new List<int>();

                        for (int i = 0; i < input.Count; i++)
                        {
                            if (input[i] >= numbersToDo)
                            {
                                filterList.Add(input[i]);
                            }
                        }
                        Console.WriteLine(string.Join(" ", filterList));
                    }
                    else if (tokens[1] == "<")
                    {
                        numbersToDo = int.Parse(tokens[2]);
                        List<int> filterList = new List<int>();

                        for (int i = 0; i < input.Count; i++)
                        {
                            if (input[i] < numbersToDo)
                            {
                                filterList.Add(input[i]);
                            }
                        }
                        Console.WriteLine(string.Join(" ", filterList));
                    }
                    else if (tokens[1] == ">")
                    {
                        numbersToDo = int.Parse(tokens[2]);
                        List<int> filterList = new List<int>();

                        for (int i = 0; i < input.Count; i++)
                        {
                            if (input[i] > numbersToDo)
                            {
                                filterList.Add(input[i]);
                            }
                        }
                        Console.WriteLine(string.Join(" ", filterList));
                    }
                    else if (tokens[1] == "<=")
                    {
                        numbersToDo = int.Parse(tokens[2]);
                        List<int> filterList = new List<int>();

                        for (int i = 0; i < input.Count; i++)
                        {
                            if (input[i] <= numbersToDo)
                            {
                                filterList.Add(input[i]);
                            }
                        }
                        Console.WriteLine(string.Join(" ", filterList));
                    }
                }
                tokens = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            if (isChange)
            {
                Console.WriteLine(string.Join(" ", input));
            }
        }
    }
}
