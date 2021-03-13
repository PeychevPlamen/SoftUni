using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.FoodShortage
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Citizen> citizen = new List<Citizen>();

            List<Rebel> rebel = new List<Rebel>();


            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input.Length == 4)
                {
                    string name = input[0];
                    string age = input[1];
                    string id = input[2];
                    string date = input[3];

                    citizen.Add(new Citizen(name, age, id, date));
                }
                else if (input.Length == 3)
                {
                    string name = input[0];
                    string age = input[1];
                    string group = input[2];

                    rebel.Add(new Rebel(name, age, group));

                }

            }

            string names = Console.ReadLine();


            while (names != "End")
            {
                if (citizen.FirstOrDefault(x => x.Name == names) != null)
                {
                    //Citizen currCitizen = citizen.FirstOrDefault(x => x.Name == names);
                    //currCitizen.BuyFood();
                    citizen.FirstOrDefault(x => x.Name == names).BuyFood();
                }
                else if (rebel.FirstOrDefault(x => x.Name == names) != null)
                {
                    rebel.FirstOrDefault(x => x.Name == names).BuyFood();
                }

                names = Console.ReadLine();
            }

            int totalFood = citizen.Sum(f => f.Food) + rebel.Sum(f => f.Food);

            Console.WriteLine(totalFood);
        }
    }
}
