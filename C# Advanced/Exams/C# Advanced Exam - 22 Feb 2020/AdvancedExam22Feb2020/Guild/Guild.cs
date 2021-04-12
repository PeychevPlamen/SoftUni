using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;
        private string name;
        private int capacity;

        public int Count => roster.Count;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Roster = new List<Player>();
        }

        public List<Player> Roster
        {
            get { return roster; }
            set { roster = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public void AddPlayer(Player player)
        {
            if (roster.Count < capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player player = roster.Find(x => x.Name == name);

            if (player != null)
            {
                roster.Remove(player);
                return true;
            }
            return false;
        }

        public void PromotePlayer(string name)
        {
            if (roster.Find(x => x.Name == name) == null || roster.Find(x => x.Name == name).Rank == "Member")
                return;
            else
            {
                roster.Find(x => x.Name == name).Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            if (roster.Find(x => x.Name == name) == null || roster.Find(x => x.Name == name).Rank == "Trial")
                return;
            else
            {
                roster.Find(x => x.Name == name).Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {
            List<Player> myListTemp = new List<Player>();

            foreach (var player in this.roster)
            {
                if (player.Class == @class)
                {
                    myListTemp.Add(player);
                }
            }
            Player[] myArrayToReturn = myListTemp.ToArray();

            this.roster = this.roster.Where(x => x.Class != @class).ToList();

            return myArrayToReturn;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {Name}");
            foreach (var player in roster)
            {
                sb
                    .AppendLine($"Player {player.Name}: {player.Class}")
                    .AppendLine($"Rank: {player.Rank}")
                    .AppendLine($"Description: {player.Description}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
