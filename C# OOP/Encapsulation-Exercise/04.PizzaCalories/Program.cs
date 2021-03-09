using System;

namespace _04.PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            string pizzaName = Console.ReadLine().Split()[1];

            string[] doughInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string doughType = doughInput[1];
            string bakingTechnique = doughInput[2];
            int doughWeight = int.Parse(doughInput[3]);

            try
            {
                Dough dough = new Dough(doughType, bakingTechnique, doughWeight);

                Pizza pizza = new Pizza(pizzaName, dough);

                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] toppingParts = command.Split();

                    string toppingName = toppingParts[1];
                    int toppingWeight = int.Parse(toppingParts[2]);

                    Topping topping = new Topping(toppingName, toppingWeight);

                    pizza.AddTopping(topping);

                    command = Console.ReadLine();
                }

                Console.WriteLine($"{pizzaName} - {pizza.TotalCallories():f2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
