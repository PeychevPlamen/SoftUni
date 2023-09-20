using System;
using System.Collections.Generic;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Queue<string> songs = new Queue<string>(input);

            string commands = Console.ReadLine();

            while (songs.Count > 0)
            {
                if (commands.Contains("Play"))
                {
                    if (songs.Count > 0)
                    {
                        songs.Dequeue();
                    }
                }
                else if (commands.Contains("Add"))
                {
                    string[] name = commands.Split("Add ", StringSplitOptions.RemoveEmptyEntries);
                    string currName = name[0];

                    if (songs.Contains(currName))
                    {
                        Console.WriteLine($"{currName} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(currName);
                    }
                }
                else if (commands.Contains("Show"))
                {
                    Console.WriteLine(string.Join(", ", songs));
                }

                commands = Console.ReadLine();
            }

            Console.WriteLine("No more songs!");
        }
    }
}
