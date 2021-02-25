using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();

            Dictionary<string, int> keyMaterial = new Dictionary<string, int>();
            Dictionary<string, int> junk = new Dictionary<string, int>();

            keyMaterial["shards"] = 0;
            keyMaterial["fragments"] = 0;
            keyMaterial["motes"] = 0;

            string leganderyItem = string.Empty;

            bool isEnought = false;

            while (true)
            {
                for (int i = 0; i < input.Length; i += 2)
                {
                    int points = int.Parse(input[i]);
                    string item = input[i + 1].ToLower();

                    if (item == "shards" || item == "fragments" || item == "motes")
                    {
                        keyMaterial[item] += points;

                        if (keyMaterial[item] >= 250)
                        {
                            keyMaterial[item] -= 250;

                            if (item == "shards")
                            {
                                leganderyItem = "Shadowmourne";
                            }
                            else if (item == "fragments")
                            {
                                leganderyItem = "Valanyr";
                            }
                            else if (item == "motes")
                            {
                                leganderyItem = "Dragonwrath";
                            }

                            isEnought = true;
                            break;
                        }
                    }
                    else
                    {
                        if (junk.ContainsKey(item) == false)
                        {
                            junk.Add(item, 0);
                        }
                        junk[item] += points;
                    }
                }
                if (isEnought)
                {
                    break;
                }

                input = Console.ReadLine()
                               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                               .ToArray();

            }

            Console.WriteLine($"{leganderyItem} obtained!");

            foreach (var item in keyMaterial.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            foreach (var item in junk.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
