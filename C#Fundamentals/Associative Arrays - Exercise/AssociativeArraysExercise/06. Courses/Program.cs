using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();


            while (input != "end")
            {
                string[] tokens = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                string courseName = tokens[0];
                string studentName = tokens[1];
                List<string> name = new List<string> { studentName };

                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName, name);
                }
                else
                {
                    courses[courseName].Add(studentName);
                }

                input = Console.ReadLine();
            }

            foreach (var item in courses.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");

                foreach (var names in item.Value.OrderBy(x=> x))
                {
                    Console.WriteLine($"-- {names}");
                }
            }
        }
    }
}
