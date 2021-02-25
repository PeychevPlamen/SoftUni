using System;
using System.Text;

namespace _06._Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder result = new StringBuilder();
            string sameLetter = string.Empty;

            for (int i = 0; i <= input.Length + 1; i++)
            {
                if (i == input.Length - 1)
                {
                    sameLetter = input[i].ToString();
                    result.Append(sameLetter);
                    break;
                }
                if (input[i] == input[i + 1])
                {
                    sameLetter = input[i].ToString();
                }
                else
                {
                    sameLetter = input[i].ToString();
                    result.Append(sameLetter);
                }
            }
            Console.WriteLine(result);
        }
    }
}
