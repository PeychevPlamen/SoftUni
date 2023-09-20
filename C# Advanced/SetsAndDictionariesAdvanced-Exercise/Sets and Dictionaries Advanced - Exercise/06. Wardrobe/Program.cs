using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int nLines = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < nLines; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                string[] clothes = input[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                foreach (var item in clothes)
                {
                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color].Add(item, 0);
                    }

                    wardrobe[color][item]++;
                }
            }

            string[] lookFor = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string lookForColor = lookFor[0];
            string lookForClothes = lookFor[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var clothes in color.Value)
                {
                    if (color.Key == lookForColor && clothes.Key == lookForClothes)
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value}");
                    }
                }
            }
        }
    }
}
