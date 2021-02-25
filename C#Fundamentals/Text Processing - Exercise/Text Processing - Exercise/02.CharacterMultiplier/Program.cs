using System;

namespace _02.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string firstWord = input[0];
            string secondWord = input[1];

            string longestWord = firstWord;
            string shortestWord = secondWord;

            if (firstWord.Length < secondWord.Length)
            {
                longestWord = secondWord;
                shortestWord = firstWord;
            }

            int totalSum = CharacterMultiplier(shortestWord, longestWord);

            Console.WriteLine(totalSum);
        }
        public static int CharacterMultiplier(string shortestWord, string longestWord)
        {
            int sum = 0;

            for (int i = 0; i < shortestWord.Length; i++)
            {
                sum += shortestWord[i] * longestWord[i];
            }
            for (int j = shortestWord.Length; j < longestWord.Length; j++)
            {
                sum += longestWord[j];
            }
            return sum;
        }
    }
}
