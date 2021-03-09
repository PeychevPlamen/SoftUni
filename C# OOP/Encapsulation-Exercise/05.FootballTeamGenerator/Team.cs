using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private string name;

        private Dictionary<string, Player> players;

        public Team(string name)
        {
            Name = name;
           
            players = new Dictionary<string, Player>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }

        public double AverageStats
        {
            get
            {
                if (players.Count == 0)
                {
                    return 0;
                }
                return Math.Round(players.Values.Average(x => x.Stats));
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player.PlayerName, player);
        }

        public void RemovePlayer(string playerName)
        {
            if (!players.ContainsKey(playerName))
            {
                throw new InvalidOperationException($"Player {playerName} is not in {Name} team.");
            }

            players.Remove(playerName);
        }
    }
}
