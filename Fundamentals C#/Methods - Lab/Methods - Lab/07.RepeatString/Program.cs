using System;

namespace _07.RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int repeatCount = int.Parse(Console.ReadLine());

            RepeatString(input, repeatCount);
        }

        private static string RepeatString(string input, int repeatCount)
        {
            string result = string.Empty;

            for (int i = 0; i < repeatCount; i++)
            {
                result = input;
                Console.Write(result);
            }
            return result;
        }
    }
}
