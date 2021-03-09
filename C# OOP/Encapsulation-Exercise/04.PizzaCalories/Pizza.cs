using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private const int MaxToppings = 10;

        private const int NameMinLenght = 1;
        private const int NameMaxLenght = 15;

        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            Name = name;
            this.dough = dough;

            toppings = new List<Topping>();
        }

        public string Name
        {
            get => name;
            private set 
            {
                if (value.Length < NameMinLenght || value.Length > NameMaxLenght || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Pizza name should be between {NameMinLenght} and {NameMaxLenght} symbols.");
                }

                name = value; 
            }
        }

        public void AddTopping (Topping topping)
        {
            if (toppings.Count == MaxToppings)
            {
                throw new InvalidOperationException($"Number of toppings should be in range [0..{MaxToppings}].");
            }

            toppings.Add(topping);
        }

        public double TotalCallories()
        {
            return dough.GetCallories() + toppings.Sum(x => x.GetCallories());
        }

    }
}
