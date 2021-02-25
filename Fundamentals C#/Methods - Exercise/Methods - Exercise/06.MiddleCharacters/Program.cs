using System;

namespace _06.MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            MiddleCharacters(input);
        }

        private static void MiddleCharacters(string input)
        {
            string output = string.Empty;

            if (input.Length % 2 == 0)
            {
                output = input.Substring(((input.Length / 2) - 1), 2);
            }
            else
            {
                output = input.Substring(input.Length / 2, 1);
            }

            Console.WriteLine(output);
        }
    }
}
