using System;

namespace _03.CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());

            CharInBetween(firstChar, secondChar);
        }

        private static void CharInBetween(char firstChar, char secondChar)
        {
            if (firstChar < secondChar)
            {
                for (int i = firstChar + 1; i < secondChar; i++)
                {
                    char currentChar = (char)(i);
                    Console.Write($"{currentChar} ");
                }
            }
            else if (firstChar > secondChar)
            {
                for (int i = secondChar + 1; i < firstChar; i++)
                {
                    char currentChar = (char)(i);
                    Console.Write($"{currentChar} ");
                }
            }
            
        }
    }
}
