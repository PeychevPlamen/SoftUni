using System;

namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Product fish = new Product("shark", 55);
            Product cake = new Product("cherryCake", 15);

            Console.WriteLine($"Ordered fish {fish.Name} with price {fish.Price}");

            var coffee = new Coffee("Starbucks", 155);

            Console.WriteLine($"{coffee.Caffeine} caffeine, {coffee.Milliliters} ml, {coffee.Name} , {coffee.Price} $.");

            var food = new Food("Pizza", 15.99M, 450);

            Console.WriteLine($"{food.Name} Peperoni, {food.Price} $, for {food.Grams} grams.");
        }
    }
}