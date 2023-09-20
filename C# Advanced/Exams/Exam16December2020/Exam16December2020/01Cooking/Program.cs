using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputLiquids = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] inputIngridients = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> liquids = new Queue<int>(inputLiquids);

            Stack<int> ingridients = new Stack<int>(inputIngridients);

            int sum = 0;

            SortedDictionary<string, int> food = new SortedDictionary<string, int>
            {
                {"Bread", 0 },
                {"Cake", 0},
                {"Pastry", 0},
                {"Fruit Pie", 0}
            };

            //int bread = 0;
            //int cake = 0;
            //int fruitPie = 0;
            //int pastry = 0;

            while (liquids.Count > 0 && ingridients.Count > 0)
            {
                sum = liquids.Peek() + ingridients.Peek();

                if (sum == 25)
                {
                    food["Bread"]++;

                    //bread++;
                    liquids.Dequeue();
                    ingridients.Pop();
                }
                else if (sum == 50)
                {

                    food["Cake"]++;

                    //cake++;
                    liquids.Dequeue();
                    ingridients.Pop();
                }
                else if (sum == 75)
                {

                    food["Pastry"]++;

                    //pastry++;
                    liquids.Dequeue();
                    ingridients.Pop();
                }
                else if (sum == 100)
                {
                    food["Fruit Pie"]++;

                    //fruitPie++;
                    liquids.Dequeue();
                    ingridients.Pop();
                }
                else
                {
                    liquids.Dequeue();
                    int tempIngridient = ingridients.Pop() + 3;
                    ingridients.Push(tempIngridient);
                }
            }

            if (food["Bread"] > 0 && food["Cake"] > 0 && food["Pastry"] > 0 && food["Fruit Pie"] > 0)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            //if (bread >= 1 && cake >= 1 && pastry >= 1 && fruitPie >= 1)
            //{
            //    Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            //}
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            if (liquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            if (ingridients.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingridients)}");
            }

            foreach (var item in food)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            //Console.WriteLine($"Bread: {bread}");
            //Console.WriteLine($"Cake: {cake}");
            //Console.WriteLine($"Fruit Pie: {fruitPie}");
            //Console.WriteLine($"Pastry: {pastry}");

        }
    }
}
