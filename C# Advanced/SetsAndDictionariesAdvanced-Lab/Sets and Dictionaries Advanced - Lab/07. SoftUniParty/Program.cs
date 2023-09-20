using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            HashSet<string> guests = new HashSet<string>();

            while (input != "PARTY")
            {
                guests.Add(input);

                input = Console.ReadLine();
            }
            while (input != "END")
            {
                guests.Remove(input);

                input = Console.ReadLine();
            }

            Console.WriteLine(guests.Count);

            foreach (var guest in guests)
            {
                char[] vipGuest = guest.ToCharArray();

                if (char.IsDigit(vipGuest[0]))
                {
                    Console.WriteLine(guest);
                }
            }
            foreach (var guest in guests)
            {
                char[] regularGuest = guest.ToCharArray();

                if (char.IsLetter(regularGuest[0]))
                {
                    Console.WriteLine(guest);
                }
            }
        }
    }
}
