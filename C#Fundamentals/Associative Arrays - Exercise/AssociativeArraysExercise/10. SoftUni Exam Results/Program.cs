using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, int> students = new Dictionary<string, int>();
            Dictionary<string, int> submissions = new Dictionary<string, int>();

            while (input != "exam finished")
            {
                string[] participant = input.Split("-", StringSplitOptions.RemoveEmptyEntries);
                string name = participant[0];
                string language = participant[1];

                if (language == "banned")
                {
                    students.Remove(name);
                }
                else
                {
                    int points = int.Parse(participant[2]);

                    if (students.ContainsKey(name) == false)
                    {
                        students.Add(name, points);
                    }
                    else
                    {
                        if (students[name] < points)
                        {
                            students[name] = points;
                        }
                    }
                    if (submissions.ContainsKey(language) == false)
                    {
                        submissions.Add(language, 0);
                    }
                    submissions[language]++;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Results:");

            foreach (var currStudent in students.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{currStudent.Key} | {currStudent.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var item in submissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
