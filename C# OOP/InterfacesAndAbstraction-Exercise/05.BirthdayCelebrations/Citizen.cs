using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BirthdayCelebrations
{
    public class Citizen : IPerson, IBirthdate
    {
        public Citizen(string name, string age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public string Age { get; private set; }

        public string Id { get; private set; }

        public string Birthdate { get; private set; }
    }
}
