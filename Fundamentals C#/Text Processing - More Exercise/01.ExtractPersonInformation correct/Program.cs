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
                string age = string.Empty;

                foreach (var item in input)
                {
                    string tokens = item;

                    if (tokens.Contains('@') && tokens.Contains('|'))
                    {
                        int firstIndex = tokens.IndexOf('@') + 1;
                        int lastIndex = tokens.IndexOf('|');
                        name = item.Substring(firstIndex, lastIndex - firstIndex);
                    }
                    if (tokens.Contains('#') && tokens.Contains('*'))
                    {
                        int firstIndex = tokens.IndexOf('#') + 1;
                        int lastIndex = tokens.IndexOf('*');
                        age = item.Substring(firstIndex, lastIndex - firstIndex);
                    }
                }
                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
