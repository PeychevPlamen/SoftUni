using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ListManipulationAdvancedVer2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToList();

            string[] command = Console.ReadLine()
                                      .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            bool isChange = false;

            while (command[0] != "end")
            {
                switch (command[0])
                {
                    case "Add":
                        input.Add(int.Parse(command[1]));
                        isChange = true;
                        break;
                    case "Remove":
                        input.Remove(int.Parse(command[1]));
                        isChange = true;
                        break;
                    case "RemoveAt":
                        input.RemoveAt(int.Parse(command[1]));
                        isChange = true;
                        break;
                    case "Insert":
                        input.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        isChange = true;
                        break;
                    case "Contains":
                        Console.WriteLine(input.Contains(int.Parse(command[1])) ? "Yes" : "No such number");
                        break;
                    case "PrintEven":
                        Console.WriteLine(string.Join(" ", input.Where(n => n % 2 == 0)));
                        break;
                    case "PrintOdd":
                        Console.WriteLine(string.Join(" ", input.Where(n => n % 2 == 1)));
                        break;
                    case "GetSum":
                        Console.WriteLine(input.Sum());
                        break;
                    case "Filter":
                        string result = string.Empty;

                        switch (command[1])
                        {
                            case "<":
                                result = string.Join(" ", input.Where(n => n < int.Parse(command[2])));
                                break;
                            case ">":
                                result = string.Join(" ", input.Where(n => n > int.Parse(command[2])));
                                break;
                            case ">=":
                                result = string.Join(" ", input.Where(n => n >= int.Parse(command[2])));
                                break;
                            case "<=":
                                result = string.Join(" ", input.Where(n => n <= int.Parse(command[2])));
                                break;
                        }
                        Console.WriteLine(result);
                        break;
                    default:
                        break;

                }
                command = Console.ReadLine()
                                 .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            if (isChange)
            {
                Console.WriteLine(string.Join(" ", input));
            }
        }
    }
}
