using System;
using System.Collections.Generic;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private int rating;

        private List<Player> players;

        public Team(string name, int rating)
        {
            Name = name;
            Rating = rating;

            players = new List<Player>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public int Rating
        {
            get { return rating; }
            set { rating = value; }
        }


    }
}
