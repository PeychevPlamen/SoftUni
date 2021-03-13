using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BirthdayCelebrations
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<IBirthdate> birthdates = new List<IBirthdate>();

            while (input != "End")
            {
                string[] tokens = input.Split();

                if (nameof(Citizen) == tokens[0])
                {
                    string name = tokens[1];
                    string age = tokens[2];
                    string id = tokens[3];
                    string birthdate = tokens[4];

                    birthdates.Add(new Citizen(name, age, id, birthdate));
                }
                else if (nameof(Pet)== tokens[0])
                {
                    string name = tokens[1];
                    string birthdate = tokens[2];

                    birthdates.Add(new Pet(name, birthdate));
                }

                input = Console.ReadLine();
            }

            string filter = Console.ReadLine();

            foreach (var birthdate in birthdates.Where(x=>x.Birthdate.EndsWith(filter)))
            {
                Console.WriteLine(birthdate.Birthdate);
            }
        }
    }
}
