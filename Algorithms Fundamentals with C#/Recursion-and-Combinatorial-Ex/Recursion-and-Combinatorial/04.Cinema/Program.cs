using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Cinema
{
    public class Program
    {
        private static List<string> nonStatickNames;
        private static string[] people;
        private static bool[] locked;

        static void Main(string[] args)
        {
            nonStatickNames = Console.ReadLine().Split(", ").ToList();
            people = new string[nonStatickNames.Count];
            locked = new bool[nonStatickNames.Count];

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "generate")
                {
                    break;
                }

                var parts = line.Split(" - ");
                var name = parts[0];
                var position = int.Parse(parts[1]);

                people[position] = name;
                locked[position] = true;

                nonStatickNames.Remove(name);
            }
        }
    }
}
