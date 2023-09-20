using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllLines("../../../words.txt");

            string text = File.ReadAllText("../../../text.txt").ToLower();

            Dictionary<string, int> repeatedWords = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                string currWord = words[i];
                int counter = 0;

                string[] wordsInText = text.Split(new string[] { " ", "-", ",", ".", "!", "?", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < wordsInText.Length; j++)
                {
                    if (currWord == wordsInText[j])
                    {
                        counter++;
                    }
                }

                if (!repeatedWords.ContainsKey(currWord))
                {
                    repeatedWords.Add(currWord, 0);
                }
                repeatedWords[currWord] = counter;
            }

            List<string> finalResult = new List<string>();
            List<string> orderedFinalResult = new List<string>();

            foreach (var item in repeatedWords)
            {
                finalResult.Add($"{item.Key} - {item.Value}");

                File.WriteAllLines("../../../actualResult.txt", finalResult);
            }

            foreach (var item in repeatedWords.OrderByDescending(x=>x.Value))
            {
                orderedFinalResult.Add($"{item.Key} - {item.Value}");

                File.WriteAllLines("../../../expectedResult.txt", orderedFinalResult);
            }
        }
    }
}
