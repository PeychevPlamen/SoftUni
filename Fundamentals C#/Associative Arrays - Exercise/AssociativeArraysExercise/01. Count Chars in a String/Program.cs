using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            Dictionary<char, int> countLetters = new Dictionary<char, int>();

            for (int i = 0; i < word.Length; i++)
            {
                char letter = word[i];

                if (letter == ' ')
                {
                    continue;
                }

                if (!countLetters.ContainsKey(letter))
                {
                    countLetters.Add(letter, 0);
                }
                countLetters[letter]++;
            }
            foreach (var chars in countLetters)
            {
                Console.WriteLine($"{chars.Key} -> {chars.Value}");
            }
        }
    }
}
