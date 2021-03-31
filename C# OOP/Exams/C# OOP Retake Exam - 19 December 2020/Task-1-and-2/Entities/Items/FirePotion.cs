using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class FirePotion : Item
    {
        private const int InitialWeight = 5;
        private const int Points = 20;

        public FirePotion() 
            : base(InitialWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            if (character.Health > Points)
            {
                character.Health -= Points;
            }
            else
            {
                character.Health = 0;
                character.IsAlive = false;
            }
        }
    }
}
