using System;
using System.Linq;

namespace _09.PalindromeIntegersVer2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                Console.WriteLine(IsPalindrome(input).ToString().ToLower());

                input = Console.ReadLine();
            }

        }

        static bool IsPalindrome(string input)
        {
            var reversed = input.Reverse().ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                if (!(reversed[i] == input[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
