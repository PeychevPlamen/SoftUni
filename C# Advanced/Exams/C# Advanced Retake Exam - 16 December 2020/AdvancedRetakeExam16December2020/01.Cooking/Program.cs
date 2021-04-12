using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liquidsCount = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] ingredientsCount = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> liquids = new Queue<int>(liquidsCount);

            Stack<int> ingredients = new Stack<int>(ingredientsCount);

            Dictionary<string, int> food = new Dictionary<string, int>
            {
                {"Bread", 0 },
                {"Cake", 0 },
                {"Pastry", 0 },
                {"Fruit Pie", 0 }
            };

            int sum = 0;
            int ingridientValue = 0;

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                sum = liquids.Peek() + ingredients.Peek();

                if (sum == 25)
                {
                    food["Bread"]++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (sum == 50)
                {
                    food["Cake"]++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (sum == 75)
                {
                    food["Pastry"]++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (sum == 100)
                {
                    food["Fruit Pie"]++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else
                {
                    ingridientValue = ingredients.Pop() + 3;
                    liquids.Dequeue();
                    ingredients.Push(ingridientValue);
                }

            }
            if (!food.ContainsValue(0))
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            if (liquids.Count > 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }
            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }
            foreach (var item in food.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
