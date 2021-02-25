using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, Dictionary<string, int>> result = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> participant = new Dictionary<string, int>();

            while (input != "no more time")
            {
                string[] tokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                string contest = tokens[1];
                int points = int.Parse(tokens[2]);


                if (!result.ContainsKey(contest))
                {
                    result.Add(contest, new Dictionary<string, int>());
                    result[contest].Add(name, points);
                }
                else
                {
                    if (result[contest].ContainsKey(name))
                    {
                        if (result[contest][name] < points)
                        {
                            participant[name] -= result[contest][name];
                            //participant[name] += points;
                            result[contest][name] = points;
                        }
                    }
                    else
                    {
                        result[contest].Add(name, points);
                    }

                }
                if (participant.ContainsKey(name))
                {
                    participant[name] += points;

                }
                else
                {
                    participant.Add(name, points);
                }
                
                input = Console.ReadLine();
            }

            int count = 0;

            foreach (var item in result.OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count} participants");

                foreach (var name in item.Value.OrderByDescending(x=>x.Value))
                {
                    count++;
                    Console.WriteLine($"{count}. {name.Key} <::> {name.Value}");
                }
                count = 0;
            }
            count = 0;
            Console.WriteLine("Individual standings:");

            foreach (var item in participant.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                count++;
                Console.WriteLine($"{count}. {item.Key} -> {item.Value}");
            }
        }
    }
}
