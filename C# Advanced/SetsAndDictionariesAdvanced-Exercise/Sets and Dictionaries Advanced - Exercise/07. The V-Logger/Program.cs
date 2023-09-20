using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, string> contestAndPassword = new Dictionary<string, string>();

            while (input != "end of contests")
            {
                string[] tokens = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string contest = tokens[0];
                string pass = tokens[1];

                contestAndPassword.Add(contest, pass);

                input = Console.ReadLine();
            }

            string candidate = Console.ReadLine();

            Dictionary<string, Dictionary<string, int>> contestantRanking = new Dictionary<string, Dictionary<string, int>>();

            while (candidate != "end of submissions")
            {
                string[] candidateInput = candidate.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = candidateInput[0];
                string pass = candidateInput[1];
                string username = candidateInput[2];
                int points = int.Parse(candidateInput[3]);

                if (contestAndPassword.ContainsKey(contest) && contestAndPassword[contest].Contains(pass))
                {
                    if (!contestantRanking.ContainsKey(username))
                    {
                        contestantRanking.Add(username, new Dictionary<string, int>());
                        contestantRanking[username].Add(contest, points);
                    }
                    else
                    {
                        if (!contestantRanking[username].ContainsKey(contest))
                        {
                            contestantRanking[username].Add(contest, points);
                        }
                        else
                        {
                            if (contestantRanking[username][contest] < points)
                            {
                                contestantRanking[username][contest] = points;
                            }
                            else
                            {
                                candidate = Console.ReadLine();
                                continue;
                            }
                        }
                    }
                }

                candidate = Console.ReadLine();
            }

            string bestUser = string.Empty;
            int currPoints = 0;
            int maxPoints = int.MinValue;

            foreach (var name in contestantRanking)
            {
                foreach (var points in name.Value)
                {
                    currPoints += points.Value;
                }
                if (currPoints > maxPoints)
                {
                    maxPoints = currPoints;
                    bestUser = name.Key;
                }
                currPoints = 0;
            }
            Console.WriteLine($"Best candidate is {bestUser} with total {maxPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var name in contestantRanking.OrderBy(x=>x.Key))
            {
                Console.WriteLine(name.Key);

                foreach (var item in name.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }
    }
}
