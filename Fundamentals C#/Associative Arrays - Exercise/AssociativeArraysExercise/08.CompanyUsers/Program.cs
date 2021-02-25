using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, List<string>> companyData = new Dictionary<string, List<string>>();

            while (input != "End")
            {
                string[] tokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string companyName = tokens[0];
                string id = tokens[1];

                List<string> companyId = new List<string>();

                if (!companyData.ContainsKey(companyName))
                {
                    companyData.Add(companyName, new List<string> { id });
                }
                else
                {
                    if (!companyData[companyName].Contains(id))
                    {
                        companyData[companyName].Add(id);
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var item in companyData.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}");

                foreach (var id in item.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}
