using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        // TODO: Implement the rest of the class.

        private double health;
        private string name;
        private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            
            Name = name;
            Health = health;
            BaseHealth = health;
            Armor = armor;
            BaseArmor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }

        public string Name
        {
            get => name;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                name = value;
            }
        }

        public double BaseHealth { get; private set; }

        public double Health
        {
            get => health;
            set
            {
                if (value > 0 || value <= BaseHealth) //??? && ?? ||
                {
                    health = value;
                }
            }
        }

        public double BaseArmor { get; private set; }

        public double Armor
        {
            get => armor;
            set
            {
                if (value > 0)
                {
                    armor = value;
                }
            }
        }

        public double AbilityPoints { get; private set; }

        public IBag Bag { get; private set; }


        public bool IsAlive { get; set; } = true;

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();

            if (Armor > hitPoints)
            {
                armor -= hitPoints;
            }
            else if (Armor < hitPoints)
            {
                hitPoints -= Armor;
                armor = 0;

                if (Health > hitPoints)
                {
                    Health -= hitPoints;
                }
                else
                {
                    health = 0;
                    IsAlive = false;
                }
            }
        }

        public void UseItem(Item item)
        {
            EnsureAlive();

            item.AffectCharacter(this);
        }
    }
}