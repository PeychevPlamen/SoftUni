using System;

namespace _03._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                                    .Split(@"\", StringSplitOptions.RemoveEmptyEntries);

            string[] path = input[input.Length - 1]
                                    .Split(".", StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine($"File name: {path[0]}");
            Console.WriteLine($"File extension: {path[1]}");

        }
    }
}
