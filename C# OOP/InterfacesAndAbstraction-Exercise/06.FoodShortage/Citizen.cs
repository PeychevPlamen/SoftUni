using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage
{
    public class Citizen : IPerson, IBirthdate, IIndentify, IBuyer
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

        public int Food { get; private set; }

        public int BuyFood()
        {
            return Food += 10;
        }
    }
}
