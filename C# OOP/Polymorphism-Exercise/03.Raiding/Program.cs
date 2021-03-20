using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<BaseHero> heroes = new List<BaseHero>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                if (type != "Druid"
                    && type != "Paladin"
                    && type != "Rogue"
                    && type != "Warrior")
                {
                    Console.WriteLine("Invalid hero!");
                    i--;
                }
                else
                {
                    BaseHero hero = CreateHero(name, type);
                    heroes.Add(hero);
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            if (heroes.Sum(x=>x.Power) >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
            
        }

        private static BaseHero CreateHero(string name, string type)
        {
            BaseHero current = null;

            if (type == "Druid")
            {
                current = new Druid(name);
            }
            else if (type == "Paladin")
            {
                current = new Paladin(name);
            }
            else if (type == "Rogue")
            {
                current = new Rogue(name);
            }
            else if (type == "Warrior")
            {
                current = new Warrior(name);
            }
            return current;
        }
    }
}
