using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage
{
    public class Rebel : IPerson, IBuyer
    {
        public Rebel(string name, string age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }

        public string Name { get; private set; }

        public string Age { get; private set; }

        public string Group { get; private set; }

        public int Food { get; private set; }

        public int BuyFood()
        {
            return Food += 5;
        }
    }
}
