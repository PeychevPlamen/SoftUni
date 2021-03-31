using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private const double currBaseHealth = 100;
        private const double currBaseArmor = 50;
        private const double currAbilityPoints = 40;

        public Warrior(string name)
            : base(name, currBaseHealth, currBaseArmor, currAbilityPoints, new Satchel())
        {
        }

       
        public void Attack(Character character)
        {
            if (character.Name == Name)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }
            if (character.IsAlive && IsAlive)
            {
                character.TakeDamage(AbilityPoints);
            }

        }
    }
}
