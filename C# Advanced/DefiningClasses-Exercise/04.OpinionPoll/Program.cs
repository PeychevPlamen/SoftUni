using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> oldestPeople = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);
                oldestPeople.Add(person);
            }

            foreach (var person in oldestPeople.Where(p=> p.Age > 30).OrderBy(p=> p.Name))
            {
                Console.WriteLine(person);
            }
        }
    }
}
