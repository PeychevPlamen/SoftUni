using System;
using System.Collections.Generic;

namespace _01._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, string> contest = new Dictionary<string, string>();

            while (input != "end of contests")
            {
                string[] inputCmd = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string contestName = inputCmd[0];
                string password = inputCmd[1];

                contest.Add(contestName, password);

                input = Console.ReadLine();
            }

            string argCmd = Console.ReadLine();

            Dictionary<string, int> contestant = new Dictionary<string, int>();
            Dictionary<string, Dictionary<string, int>> nameAndPass= new Dictionary<string, Dictionary<string, int>>();

            while (argCmd != "end of submissions")
            {
                string[] submissions = argCmd.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string currContestName = submissions[0];
                string currPass = submissions[1];
                string contestantName = submissions[2];
                int contestantPoints = int.Parse(submissions[3]);

                if (contest.ContainsKey(currContestName))
                {
                    if (contest.ContainsValue(currPass))
                    {
                        if (!contestant.ContainsKey(contestantName))
                        {
                            contestant.Add(contestantName, contestantPoints);
                        }
                        // else
                        // {
                        //     if (contestant[contestantName] < contestantPoints)
                        //     {
                        //         contestant[contestantName] = contestantPoints;
                        //     }
                        // }
                        if (!nameAndPass.ContainsKey(currContestName))
                        {
                            nameAndPass.Add(currContestName, contestant);
                        }
                    }
                }


                argCmd = Console.ReadLine();
            }
        }
    }
}
