using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfStudents = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> studentsResults = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < numOfStudents; i++)
            {
                string[] input = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!studentsResults.ContainsKey(name))
                {
                    studentsResults.Add(name, new List<decimal>());
                }

                studentsResults[name].Add(grade);
            }
            foreach (var name in studentsResults)
            {
                Console.Write($"{name.Key} -> ");

                foreach (var item in name.Value)
                {
                    Console.Write($"{item:f2} ");

                }

                Console.WriteLine($"(avg: {name.Value.Average():f2})");

            }


            //foreach (var item in studentsResults)
            //{
            //    Console.WriteLine($"{item.Key} -> {string.Join(" ", item.Value.Select(x=>Math.Round(x, 2)))} {$"(avg: {item.Value.Average():f2})"}");
            //}
        }
    }
}
