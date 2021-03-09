using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                string[] commands = input.Split(";", StringSplitOptions.RemoveEmptyEntries);

                string currCmd = commands[0];
                string currTeam = commands[1];
                
                try
                {
                    if (currCmd == "Team")
                    {
                        teams.Add(new Team(currTeam));
                    }
                    else if (currCmd == "Add")
                    {
                        string namePlayer = commands[2];

                        int endurance = int.Parse(commands[3]);
                        int sprint = int.Parse(commands[4]);
                        int dribble = int.Parse(commands[5]);
                        int passing = int.Parse(commands[6]);
                        int shooting = int.Parse(commands[7]);

                        if (!teams.Any(x => x.Name == currTeam))
                        {
                            throw new ArgumentException($"Team {currTeam} does not exist.");

                        }
                        Team currentTeam = teams.First(t => t.Name == currTeam);

                        Player player = new Player(namePlayer, endurance, sprint, dribble, passing, shooting);

                        currentTeam.AddPlayer(player);
                    }
                    else if (currCmd == "Remove")
                    {
                        string namePlayer = commands[2];

                        Team teamToRemove = teams.FirstOrDefault(x => x.Name == currTeam);

                        teamToRemove.RemovePlayer(namePlayer);
                    }
                    else if (currCmd == "Rating")
                    {

                        if (!teams.Any(x => x.Name == currTeam))
                        {
                            throw new ArgumentException($"Team {currTeam} does not exist.");

                        }


                        Team team = teams.FirstOrDefault(x => x.Name == currTeam);

                        Console.WriteLine($"{currTeam} - {team.AverageStats}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }
        }
    }
}
