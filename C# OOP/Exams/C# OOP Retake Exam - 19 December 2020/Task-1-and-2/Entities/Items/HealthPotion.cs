using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class HealthPotion
    {
        private const int Weight = 5;

        public HealthPotion(int health)
        {
            Health = health;
        }

        public int Health { get; private set; }

        void AffectCharacter(Character character)
        {
            if (character.IsAlive)
            {
                Health += 20;
            }
        }
    }
}
