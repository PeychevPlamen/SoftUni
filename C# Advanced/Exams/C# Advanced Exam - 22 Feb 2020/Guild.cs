using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => roster.Count;
        public Guild(string name, int capacity)
        {

            this.Name = name;
            this.Capacity = capacity;
            roster = new List<Player>();
        }
        public void AddPlayer(Player player)
        {
            if (Capacity > Count)
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
            else
            {
                return false;
            }

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
        public Player[] KickPlayersByClass(string classy)
        {

            List<Player> myListTemp = new List<Player>();
            foreach (var player in this.roster)
            {
                if (player.Class == classy)
                {
                    myListTemp.Add(player);
                }
            }
            Player[] myArrayToReturn = myListTemp.ToArray();

            this.roster = this.roster.Where(x => x.Class != classy).ToList();

            return myArrayToReturn;
        }
        public string Report()
        {
            StringBuilder myString = new StringBuilder();
            myString.AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in this.roster)
            {
                myString.AppendLine($"Player {player.Name}: {player.Class}");
                myString.AppendLine($"Rank: {player.Rank}");
                myString.AppendLine($"Description: {player.Description}");
            }
            return myString.ToString().TrimEnd();
        }
    }
}