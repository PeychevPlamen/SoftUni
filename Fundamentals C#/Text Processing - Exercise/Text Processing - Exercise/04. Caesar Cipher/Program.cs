using System;
using System.Text;

namespace _04._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder output = new StringBuilder();

            foreach (char ch in input)
            {
                var letter = ch + 3;
                output.Append((char)letter);
            }
            Console.WriteLine(output);
        }
    }
}
