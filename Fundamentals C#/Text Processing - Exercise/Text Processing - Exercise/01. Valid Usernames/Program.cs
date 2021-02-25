using System;
using System.Linq;

namespace _01._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in input)
            {
                var curr = item;

                if (IsValid(curr))
                {
                    Console.WriteLine(curr);
                }
            }
        }

        private static bool IsValid(string curr)
        {
            return curr.Length >= 3 && curr.Length <= 16
                                    && curr.All(c => char.IsLetterOrDigit(c))
                                    || curr.Contains('-')
                                    || curr.Contains("_");
        }
    }
}
