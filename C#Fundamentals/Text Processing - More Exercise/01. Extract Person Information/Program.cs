using System;

namespace _01._Extract_Person_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = string.Empty;
                int age = 0;

                foreach (var item in input)
                {
                    string tokens = item;

                    if (tokens[0] == '@' && tokens[tokens.Length - 1] == '|')
                    {
                        name = item.Substring(1, tokens.Length - 2);
                    }
                    else if (tokens[0] == '#' && tokens[tokens.Length - 1] == '*')
                    {
                        age = int.Parse(item.Substring(1, tokens.Length - 2));
                    }
                }
                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
