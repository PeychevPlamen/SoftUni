using System;

namespace _03.Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine().ToLower();
            string line = Console.ReadLine().ToLower();

            int startIndex = line.IndexOf(word);

            while (startIndex != -1)
            {
                line = line.Remove(startIndex, word.Length);

                startIndex = line.IndexOf(word);
            }
            Console.WriteLine(line);
        }
    }
}
