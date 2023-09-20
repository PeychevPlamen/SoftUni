using System;
using System.Collections.Generic;

namespace _04._CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputLines = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> output = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < inputLines; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string continent = input[0];
                string countries = input[1];
                string cities = input[2];

                if (!output.ContainsKey(continent))
                {
                    output.Add(continent, new Dictionary<string, List<string>>());

                }
                if (!output[continent].ContainsKey(countries))
                {
                    output[continent].Add(countries, new List<string>());
                }

                output[continent][countries].Add(cities);

            }

            foreach (var item in output)
            {
                Console.WriteLine($"{item.Key}:");

                foreach (var country in item.Value)
                {
                    Console.WriteLine($"{country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
