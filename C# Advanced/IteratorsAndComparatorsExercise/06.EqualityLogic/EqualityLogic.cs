using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public int CompareTo(Person other)
        {
            int result = 1;

            if (other != null)
            {
                result = Name.CompareTo(other.Name);

                if (result == 0)
                {
                    result = Age.CompareTo(other.Age);
                }
            };

            return result;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Age.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (this.GetHashCode() == obj.GetHashCode())
            {
                return true;
            }
            else
            {
                return false;

            }
        }
    }
}