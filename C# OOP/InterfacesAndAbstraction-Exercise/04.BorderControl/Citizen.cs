using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public class Citizen : IName, IAge, IIdentify
    {
        public Citizen(string name, string age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }

        public string Name { get; private set; }

        public string Age { get; private set; }

        public string Id { get; private set; }
    }
}
