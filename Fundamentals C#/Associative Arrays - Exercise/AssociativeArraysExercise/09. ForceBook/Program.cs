using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, List<string>> forceBook = new Dictionary<string, List<string>>();

            while (input != "Lumpawaroo")
            {
                if (input.Contains("|"))
                {
                    string[] tokens = input.Split(" | ");
                    string side = tokens[0];
                    string name = tokens[1];

                    if (!forceBook.ContainsKey(side))
                    {
                        forceBook.Add(side, new List<string> { name });
                    }
                    else
                    {
                        forceBook[side].Add(name);
                    }

                }
                else if (input.Contains("->"))
                {
                    string[] tokens = input.Split(" -> ");
                    string name = tokens[0];
                    string side = tokens[1];

                    if (!forceBook.ContainsValue(new List<string> { name }))
                    {
                        foreach (var item in forceBook.Values)
                        {
                            if (item.Contains(name))
                            {
                                item.Remove(name);
                            }
                        }

                        forceBook[side].Add(name);

                        Console.WriteLine($"{name} joins the {side} side!");
                    }
                    // else
                    // {
                    //     forceBook.Add(side, new List<string> { name });
                    // }
                }

                input = Console.ReadLine();
            }

            foreach (var item in forceBook.OrderByDescending(x=> x.Value.Count).ThenBy(x=> x.Key))
            {
                if (item.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");

                    foreach (var name in item.Value.OrderBy(x=> x))
                    {
                        Console.WriteLine($"! {name}");
                    }
                   
                }
                
            }
        }
    }
}
