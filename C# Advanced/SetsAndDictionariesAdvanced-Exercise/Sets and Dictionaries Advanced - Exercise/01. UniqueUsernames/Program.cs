using System;
using System.Collections.Generic;

namespace _01._UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int nLines = int.Parse(Console.ReadLine());

            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < nLines; i++)
            {
                names.Add(Console.ReadLine());
            }
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
