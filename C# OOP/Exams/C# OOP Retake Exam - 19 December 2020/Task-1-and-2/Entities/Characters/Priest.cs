using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        private const double currBaseHealth = 50;
        private const double currBaseArmor = 25;
        private const double currAbilityPoints = 40;

        public Priest(string name) 
            : base(name, currBaseHealth, currBaseArmor, currAbilityPoints, new Backpack())
        {
        }

        public void Heal(Character character)
        {

            if (character.IsAlive && IsAlive)
            {
                character.Health += AbilityPoints;
            }
        }
    }
}
