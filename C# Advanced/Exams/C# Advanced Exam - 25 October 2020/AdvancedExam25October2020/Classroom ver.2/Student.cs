using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomProject
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Subject { get; set; }




        public Student(string FirstName, string LastName, string Subject)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Subject = Subject;

        }

        public override string ToString()
        {
            StringBuilder myStringToReturn = new StringBuilder();
            myStringToReturn.AppendLine($"Student: First Name = { FirstName}, Last Name = { LastName }, Subject = { Subject }");

            return myStringToReturn.ToString().TrimEnd();

        }
    }
}
