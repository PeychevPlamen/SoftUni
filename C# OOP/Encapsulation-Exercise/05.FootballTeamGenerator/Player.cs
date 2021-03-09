using System;
using System.Collections.Generic;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Player
    {
        private const int minStats = 0;
        private const int maxStats = 100;

        private string playerName;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string playerName, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            PlayerName = playerName;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public string PlayerName
        {
            get => playerName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                playerName = value;
            }
        }

        public int Endurance
        {
            get => endurance;
            private set
            {
                if (value < minStats || value > maxStats)
                {
                    throw new ArgumentException($"{value} should be between {minStats} and {maxStats}.");
                }

                endurance = value;
            }
        }

        public int Sprint
        {
            get => sprint;
            private set
            {
                if (value < minStats || value > maxStats)
                {
                    throw new ArgumentException($"{value} should be between {minStats} and {maxStats}.");
                }

                sprint = value;
            }
        }

        public int Dribble
        {
            get => dribble;
            private set
            {
                if (value < minStats || value > maxStats)
                {
                    throw new ArgumentException($"{value} should be between {minStats} and {maxStats}.");
                }

                dribble = value;
            }
        }

        public int Passing
        {
            get => passing;
            private set
            {
                if (value < minStats || value > maxStats)
                {
                    throw new ArgumentException($"{value} should be between {minStats} and {maxStats}.");
                }

                passing = value;
            }
        }

        public int Shooting
        {
            get => shooting;
            private set
            {
                if (value < minStats || value > maxStats)
                {
                    throw new ArgumentException($"{value} should be between {minStats} and {maxStats}.");
                }

                shooting = value;
            }
        }
    }
}
