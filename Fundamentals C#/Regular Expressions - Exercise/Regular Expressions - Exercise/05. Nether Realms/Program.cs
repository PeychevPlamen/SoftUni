using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _05._Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string patternLetters = @"([A-z])";
            string patternDigits = @"[-+]?[0-9]+\.?[0-9]*";

            Regex regexLetters = new Regex(patternLetters);
            Regex regexDigits = new Regex(patternDigits);

            Dictionary<string, Dictionary<int, double>> output = new Dictionary<string, Dictionary<int, double>>();

            double damage = 0;
            int health = 0;
            string demon = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                damage = 0;
                health = 0;
                demon = input[i];

                StringBuilder demonHealth = new StringBuilder();

                MatchCollection currDemonLetters = regexLetters.Matches(demon);
                MatchCollection currDemonDigits = regexDigits.Matches(demon);

                foreach (Match item in currDemonLetters)
                {
                    demonHealth.Append(item.Value);

                }
                foreach (Match digit in currDemonDigits)
                {
                    damage += double.Parse(digit.Value);
                }
                for (int j = 0; j < demon.Length; j++)
                {
                    if (demon[j] == '*')
                    {
                        damage *= 2;
                    }
                    else if (demon[j] == '/')
                    {
                        damage /= 2;
                    }
                }
                string currHealth = demonHealth.ToString();

                foreach (var item in currHealth)
                {
                    health += item;
                }

                Dictionary<int, double> healthAndDamage = new Dictionary<int, double> { { health, damage } };

                output.Add(demon, healthAndDamage);

            }
            foreach (var item in output.OrderBy(x => x.Key))
            {
                foreach (var exit in item.Value)
                {
                    Console.WriteLine($"{item.Key} - {exit.Key} health, {exit.Value:f2} damage");
                }

            }
        }
    }
}
