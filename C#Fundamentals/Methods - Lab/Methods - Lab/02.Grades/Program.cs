using System;

namespace _02.Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            double input = double.Parse(Console.ReadLine());

            GradeOutput(input);
        }

        private static void GradeOutput(double input)
        {
            string grade = string.Empty;

            if (input >= 2.00 && input < 3)
            {
                grade = "Fail";
            }
            else if (input >= 3.00 && input < 3.50)
            {
                grade = "Poor";
            }
            else if (input >= 3.50 && input < 4.50)
            {
                grade = "Good";
            }
            else if (input >= 4.50 && input < 5.50)
            {
                grade = "Very good";
            }
            else if (input >= 5.50 && input <= 6.00)
            {
                grade = "Excellent";
            }

            Console.WriteLine(grade);
        }
    }
}
