using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, Trainer> trainerData = new Dictionary<string, Trainer>();

            while (input != "Tournament")
            {
                string[] currInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = currInput[0];
                string pokemonName = currInput[1];
                string pokemonElement = currInput[2];
                int pokemonHealth = int.Parse(currInput[3]);

                if (!trainerData.ContainsKey(trainerName))
                {
                    trainerData.Add(trainerName, new Trainer(trainerName));

                }
                Trainer trainer = trainerData[trainerName];

                Pokemon currPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                trainer.CollectionOfPokemon.Add(currPokemon);

                input = Console.ReadLine();
            }

            string commands = Console.ReadLine();

            while (commands != "End")
            {
                string element = commands;

                foreach (var trainer in trainerData)
                {
                    if (trainer.Value.CollectionOfPokemon.Any(p=> p.Element == element))
                    {
                        trainer.Value.NumOfBadges++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Value.CollectionOfPokemon)
                        {
                            pokemon.Health -= 10;
                        }
                        trainer.Value.CollectionOfPokemon.RemoveAll(p => p.Health <= 0);
                    }
                }

                commands = Console.ReadLine();
            }
            Dictionary<string, Trainer> result = trainerData
                .OrderByDescending(x => x.Value.NumOfBadges)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} {item.Value.NumOfBadges} {item.Value.CollectionOfPokemon.Count}");
            }
        }
    }
}
