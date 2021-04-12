using System;
using System.Collections.Generic;
using System.IO;

namespace EqualityLogic
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<Person> sorted = new SortedSet<Person>();
            HashSet<Person> hashSet = new HashSet<Person>();


            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(input[0], int.Parse(input[1]));
                sorted.Add(person);
                hashSet.Add(person);
            }

            Console.WriteLine(sorted.Count);
            Console.WriteLine(hashSet.Count);
        }
    }
}