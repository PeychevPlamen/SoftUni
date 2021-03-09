using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private const int minWeight = 1;
        private const int maxWeight = 50;

        private string name;
        private int weight;

        public Topping(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name
        {
            get => name;
            private set
            {
                string valueAsLower = value.ToLower();

                if (valueAsLower != "meat" &&
                    valueAsLower != "veggies" &&
                    valueAsLower != "cheese" &&
                    valueAsLower != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                name = value;
            }
        }

        public int Weight
        {
            get => weight;
            private set
            {
                if (value < minWeight || value > maxWeight)
                {
                    throw new ArgumentException($"{Name} weight should be in the range [{minWeight}..{maxWeight}].");
                }
                weight = value;
            }
        }

        public double GetCallories()
        {
            double modifier = GetModifier();

            return Weight * 2 * modifier;
        }

        private double GetModifier()
        {
            string toppingNameLower = Name.ToLower();

            if (toppingNameLower == "meat")
            {
                return 1.2;
            }
            if (toppingNameLower == "veggies")
            {
                return 0.8;
            }
            if (toppingNameLower == "cheese")
            {
                return 1.1;
            }

            return 0.9;
        }
    }
}
