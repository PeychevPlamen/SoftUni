using System;
using System.Collections.Generic;

namespace _05._SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfCmd = int.Parse(Console.ReadLine());

            Dictionary<string, string> output = new Dictionary<string, string>();

            for (int i = 0; i < numOfCmd; i++)
            {
                string[] input = Console.ReadLine().Split();
                string cmd = input[0];
                string name = input[1];

                if (cmd == "register")
                {
                    string plate = input[2];

                    if (!output.ContainsKey(name))
                    {
                        output.Add(name, plate);
                        Console.WriteLine($"{name} registered {plate} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {plate}");
                    }
                }
                else if (cmd == "unregister")
                {
                    if (output.ContainsKey(name))
                    {
                        output.Remove(name);
                        Console.WriteLine($"{name} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                }
            }

            foreach (var item in output)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
