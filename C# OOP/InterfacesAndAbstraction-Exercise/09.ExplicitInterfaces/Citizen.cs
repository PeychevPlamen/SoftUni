using System;
using System.Collections.Generic;
using System.Text;

namespace _09.ExplicitInterfaces
{
    public class Citizen : IPerson, IResident
    {
        public Citizen(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public string Country { get; private set; }

        public string Age { get; private set; }

        string IPerson.GetName()
        {
            return Name;
        }
        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {Name}";
        }
    }
}
