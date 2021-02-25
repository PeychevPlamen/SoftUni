using System;
using System.Linq;

namespace _05.WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(n => n.Length % 2 == 0)
                .ToArray();

            // foreach (var word in words)
            // {
            //     Console.WriteLine(word);
            // }
            //    == or ==
            // Console.Write(string.Join(Environment.NewLine, words));

            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
