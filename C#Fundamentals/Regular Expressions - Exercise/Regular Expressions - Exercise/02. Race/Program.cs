using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace _02._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string patternName = @"[A-Za-z]";
            string patternNums = @"[0-9]";

            string[] names = Console.ReadLine()
                                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string input = Console.ReadLine();

            Regex regexName = new Regex(patternName);
            Regex regexDistance = new Regex(patternNums);

            Dictionary<string, int> finalResult = new Dictionary<string, int>();

            foreach (var item in names)
            {
                finalResult.Add(item, 0);
            }

            while (input != "end of race")
            {
                MatchCollection matchName = regexName.Matches(input);
                MatchCollection matchNum = regexDistance.Matches(input);

                StringBuilder currName = new StringBuilder();
                int totalDistance = 0;

                foreach (Match item in matchName)
                {
                    string name = item.Value;
                    currName.Append(name);
                }
                foreach (Match num in matchNum)
                {
                    int currNum = int.Parse(num.Value);
                    totalDistance += currNum;
                }

                if (finalResult.ContainsKey(currName.ToString()))
                {
                    finalResult[currName.ToString()] += totalDistance;
                    totalDistance = 0;
                }

                input = Console.ReadLine();
            }

            int counter = 0;

            foreach (var name in finalResult.OrderByDescending(x => x.Value))
            {
                counter++;

                if (counter == 1)
                {
                    Console.WriteLine($"1st place: {name.Key}");
                }
                else if (counter == 2)
                {
                    Console.WriteLine($"2nd place: {name.Key}");
                }
                else if (counter == 3)
                {
                    Console.WriteLine($"3rd place: {name.Key}");
                }
                else
                {
                    break;
                }
            }
        }
    }
}
