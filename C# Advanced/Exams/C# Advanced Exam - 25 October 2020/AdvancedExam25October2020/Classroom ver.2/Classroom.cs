using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public int Capacity { get; set; }

        public int Count => students.Count;
        public Classroom(int capacity)
        {


            this.Capacity = capacity;
            students = new List<Student>();

        }
        public string RegisterStudent(Student student)
        {
            if (Capacity > Count)
            {
                students.Add(student);
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Added student {student.FirstName} {student.LastName}").ToString();


                return sb.ToString().TrimEnd();
            }
            else
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"No seats in the classroom").ToString();


                return sb.ToString().TrimEnd();
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student student = students.Find(x => x.FirstName == firstName);
            if (student != null)
            {
                students.Remove(student);
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Dismissed student {firstName} {lastName}").ToString();


                return sb.ToString().TrimEnd();
            }
            else
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Student not found").ToString();


                return sb.ToString().TrimEnd();
            }

        }


        public Student GetStudent(string firstName, string lastName)
        {
            Student manufacturerToGet = students.Find(x => x.FirstName == firstName);


            if (manufacturerToGet != null)
            {
                return manufacturerToGet;
            }
            else
            {
                return null;
            }
        }
        public int GetStudentsCount()
        {
            return Count;
        }
        public string GetSubjectInfo(string subject)
        {
            List<Student> studentsSelect = students.Where(s => s.Subject == subject).ToList();
            if (studentsSelect.Count == 0)
            {
                return "No students enrolled for the subject";
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");
            foreach (Student student in studentsSelect)
            {
                sb.AppendLine($"{student.FirstName} {student.LastName}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
    