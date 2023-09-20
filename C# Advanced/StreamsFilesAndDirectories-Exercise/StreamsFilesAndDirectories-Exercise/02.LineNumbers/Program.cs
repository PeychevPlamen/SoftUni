using System;
using System.IO;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");

            string[] result = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                int coutOfLetters = countLetters(line);
                int countOfPunct = countPunctuation(line);

                result[i] = $"Line {i+1}: {lines[i]} ({coutOfLetters})({countOfPunct})";

                File.WriteAllLines("../../../output.txt", result);
            }
        }
       static int countLetters(string line)
        {
            int counterLetter = 0;

            for (int i = 0; i < line.Length; i++)
            {
                char symbol = line[i];

                if (Char.IsLetter(symbol))
                {
                    counterLetter++;
                }
            }
            return counterLetter;
        }
        static int countPunctuation(string line)
        {
            int counterPunct = 0;

            for (int i = 0; i < line.Length; i++)
            {
                char symbol = line[i];

                if (Char.IsPunctuation(symbol))
                {
                    counterPunct++;
                }
            }
            return counterPunct;
        }
    }
}
