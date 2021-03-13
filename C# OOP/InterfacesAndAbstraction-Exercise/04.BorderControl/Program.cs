using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<IIdentify> indentify = new List<IIdentify>(); 

            while (input!= "End")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 2)
                {
                    string model = tokens[0];
                    string id = tokens[1];

                    indentify.Add(new Robot(model, id));
                }
                else if (tokens.Length == 3)
                {
                    string name = tokens[0];
                    string age = tokens[1];
                    string id = tokens[2];

                    indentify.Add(new Citizen(name, age, id));
                }

                input = Console.ReadLine();
            }

            string fakeIdEnds = Console.ReadLine();

            foreach (var item in indentify.Where(x=>x.Id.EndsWith(fakeIdEnds)))
            {
                Console.WriteLine(item.Id);
            }
        }
    }
}
