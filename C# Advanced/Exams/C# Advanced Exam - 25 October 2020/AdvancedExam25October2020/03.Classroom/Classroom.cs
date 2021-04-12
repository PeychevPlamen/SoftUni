using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;
        private int capacity;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            this.students = new List<Student>();
        }

        public List<Student> Students
        {
            get { return students; }
            set { students = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public int Count => this.students.Count;

        public string RegisterStudent(Student student)
        {
            if (this.students.Count < capacity)
            {
                this.students.Add(student);

                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student student = this.students.FirstOrDefault(x=>x.FirstName == firstName);

            if (student != null)
            {
                this.students.Remove(student);
                return $"Dismissed student {firstName} {lastName}";

            }
            else
            {
                return "Student not found";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> studentsBySubject = students.Where(x => x.Subject == subject).ToList();

            StringBuilder sb = new StringBuilder();

            if (studentsBySubject.Count > 0)
            {
                sb
                    .AppendLine($"Subject: {subject}")
                    .AppendLine("Students:");

                foreach (var student in studentsBySubject)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }

                return sb.ToString().TrimEnd();   
            }
            else
            {
                return "No students enrolled for the subject";
            }
        }
        public int GetStudentsCount()
        {
            return Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            Student student = this.students.FirstOrDefault(x => x.FirstName == firstName);

            return student;
        }
    }
}
