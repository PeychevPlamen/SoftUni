using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
        public string Name { get; set; }
        public string Class { get; set; }

        public string Rank { get; set; }

        public string Description { get; set; }

        public Player(string name, string @class)
        {
            this.Name = name;
            this.Class = @class;
            this.Rank = "Trial";
            this.Description = "n/a";
        }

        public override string ToString()
        {
            StringBuilder myStringToReturn = new StringBuilder();
            myStringToReturn.AppendLine($"Player {Name}: {Class}");
            myStringToReturn.AppendLine($"Rank: {Rank}");
            myStringToReturn.AppendLine($"Description: {Description}");
            return myStringToReturn.ToString().TrimEnd();

        }
    }
}
