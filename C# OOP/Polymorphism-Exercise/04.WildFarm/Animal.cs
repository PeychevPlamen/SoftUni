using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public abstract class Animal
    {
        protected Animal(string name, double weight, HashSet<string> allowedFood, double weightModifier)
        {
            Name = name;
            Weight = weight;

            AllowedFood = allowedFood;
            WeightModifier = weightModifier;
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        private HashSet<string> AllowedFood { get; set; }

        private double WeightModifier { get; set; }


        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, ";
        }

        public void Eat(Food food)
        {
            if (!AllowedFood.Contains(food.GetType().Name))
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }

            FoodEaten += food.Quantity;
            Weight += WeightModifier * food.Quantity;

        }
    }
}
