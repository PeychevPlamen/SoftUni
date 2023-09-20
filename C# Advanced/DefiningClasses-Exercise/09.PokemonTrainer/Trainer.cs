using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09.PokemonTrainer
{
    public class Trainer
    {

        public Trainer(string name)
        {
            this.Name = name;
            this.NumOfBadges = 0;
            this.CollectionOfPokemon = new List<Pokemon>();
        }

        public string Name { get; set; }

        public int NumOfBadges { get; set; }

        public List<Pokemon> CollectionOfPokemon { get; set; }


    }
}
