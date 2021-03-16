using System;
using System.Collections.Generic;

namespace _09.ExplicitInterfaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Citizen> citizen = new List<Citizen>();

            while (input != "End")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Citizen name = new Citizen(tokens[0]);
                citizen.Add(name);

                input = Console.ReadLine();
            }

            foreach (var item in citizen)
            {
                Console.WriteLine(((IPerson)item).GetName());
                Console.WriteLine(((IResident)item).GetName());
            }
            

        }
    }
}
