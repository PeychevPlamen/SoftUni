using System;

namespace _08._Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            double result = 0;
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            //   A12b s17G

            for (int i = 0; i < input.Length; i++)
            {
                string curr = input[i]; // A12b

                char firstLetter = curr[0]; // A
                char lastLetter = curr[curr.Length - 1]; // b

                double number = double.Parse(curr.Substring(1, curr.Length - 2)); // 12

                int firstIndex = alphabet.IndexOf(char.ToUpper(firstLetter));
                int lastIndex = alphabet.IndexOf(char.ToUpper(lastLetter));

                if (firstLetter >= 65 && firstLetter <= 90)
                {
                    number = number / (firstIndex + 1);
                }
                else if (firstLetter >= 97 && firstLetter <= 122)
                {
                    number = number * (firstIndex + 1);
                }
                if (lastLetter >= 65 && lastLetter <= 90)
                {
                    number = number - (lastIndex + 1);
                }
                else if (lastLetter >= 97 && lastLetter <= 122)
                {
                    number = number + (lastIndex + 1);
                }
                result += number;
            }
            Console.WriteLine($"{result:f2}");
        }
    }
}
