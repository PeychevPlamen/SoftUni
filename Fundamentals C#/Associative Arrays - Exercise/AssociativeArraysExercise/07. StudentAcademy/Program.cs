using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            int numStudents = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> output = new Dictionary<string, List<double>>();

            for (int i = 0; i < numStudents; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                List<double> currGrade = new List<double> { grade };

                if (output.ContainsKey(name) == false)
                {
                    output.Add(name, currGrade);
                }
                else
                {
                    output[name].Add(grade);
                }

            }
            foreach (var student in output.OrderByDescending(x => x.Value.Average(n => n)))
            {
                double averageGrade = student.Value.Average(x => x);

                if (averageGrade >= 4.50)
                {
                    Console.WriteLine($"{student.Key} -> {(averageGrade):f2}");

                }
            }
        }
    }
}
