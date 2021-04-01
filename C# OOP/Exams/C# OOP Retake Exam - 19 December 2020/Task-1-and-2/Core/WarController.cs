using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<Character> characters;
        private List<Item> items;
        public WarController()
        {
            characters = new List<Character>();
            items = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            Character character = null;

            string typeOfCharacter = args[0];
            string nameOfCharacter = args[1];

            if (typeOfCharacter == "Warrior")
            {
                character = new Warrior(nameOfCharacter);
            }
            else if (typeOfCharacter == "Priest")
            {
                character = new Priest(nameOfCharacter);
            }
            else
            {
                throw new ArgumentException($"Invalid character type {typeOfCharacter}!");
            }
            characters.Add(character);

            return $"{nameOfCharacter} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            Item item = null;

            string itemName = args[0];

            if (itemName == "HealthPotion")
            {
                item = new HealthPotion();
            }
            else if (itemName == "FirePotion")
            {
                item = new FirePotion();
            }
            else
            {
                throw new ArgumentException($"Invalid item {itemName}!");
            }

            items.Add(item);
            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string charachterName = args[0];

            Character character = characters.FirstOrDefault(x => x.Name == charachterName);

            if (character == null)
            {
                throw new ArgumentException($"Character {charachterName} not found!");
            }
            else if (!items.Any())
            {
                throw new ArgumentException($"No items left in pool!");
            }

            character.Bag.AddItem(items.Last());

            return $"{charachterName} picked up {items.Last()}!"; // ??????????????? 
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = characters.FirstOrDefault(x => x.Name == characterName);
            Item item = character.Bag.GetItem(itemName);

            if (characters.Any(x => x.Name == characterName))
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            character.UseItem(item);

            return $"{character.Name} used {itemName}.";

        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var character in characters.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                sb.AppendLine(character.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Warrior attacker = (Warrior)characters.Where(x => x.GetType().Name == nameof(Warrior)).FirstOrDefault(x => x.Name == attackerName);
            Character receiver = characters.FirstOrDefault(x => x.Name == receiverName);

            if (attacker == null)
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }
            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }
            if (!attacker.IsAlive)
            {
                throw new ArgumentException($"{attackerName} cannot attack!");
            }
            attacker.Attack(receiver);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (!receiver.IsAlive)
            {
                sb.AppendLine($"{receiverName} is dead!");
            }

            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            Priest healer = (Priest)characters.Where(c => c.GetType().Name == nameof(Priest)).FirstOrDefault(c => c.Name == healerName);
            Character receiver = characters.FirstOrDefault(x => x.Name == healingReceiverName);

            if (healer == null)
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }
            if (healingReceiverName == null)
            {
                throw new ArgumentException($"Character {healingReceiverName} not found!");
            }
            if (!healer.IsAlive)
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            healer.Heal(receiver);

            return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
        }
    }
}
