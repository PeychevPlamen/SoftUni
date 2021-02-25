using System;

namespace _02.VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            VowelsCount(input);
        }

        private static void VowelsCount(string input)
        {
            string newInput = input.ToLower();
            int counter = 0;

            for (int i = 0; i < newInput.Length; i++)
            {
                string currentLetter = newInput[i].ToString();

                if (currentLetter == "a")
                {
                    counter++;
                }
                else if (currentLetter == "e")
                {
                    counter++;
                }
                else if (currentLetter == "o")
                {
                    counter++;
                }
                else if (currentLetter == "i")
                {
                    counter++;
                }
                else if (currentLetter == "u")
                {
                    counter++;
                }
                else if (currentLetter == "y")
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
