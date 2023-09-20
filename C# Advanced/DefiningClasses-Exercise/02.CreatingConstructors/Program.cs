using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person();

            Console.WriteLine($"Name is: {person.Name}, {person.Age} years old.");
        }
    }
}
