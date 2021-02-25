using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Treasure_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            var key = Console.ReadLine()
                             .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string input = Console.ReadLine();

            int numOfKey = 0;
            
            while (input != "find")
            {
                StringBuilder decoded = new StringBuilder();

                for (int i = 0; i < input.Length; i += key.Length)
                {
                    for (int j = 0; j < key.Length; j++)
                    {
                        if (i + j >= input.Length)
                        {
                            break;
                        }

                        numOfKey = int.Parse(key[j]);

                        char decodedCh = (char)(input[i + j] - numOfKey);
                        decoded.Append(decodedCh);

                    }
                }
                string output = decoded.ToString();
                int startIdexOfMaterial = output.IndexOf('&') + 1;
                int endIndexOfMaterial = output.LastIndexOf('&');
                int startIndexCoordinate = output.IndexOf('<') + 1;
                int endIndexCoordinate = output.LastIndexOf('>');

                string material = output.Substring(startIdexOfMaterial, endIndexOfMaterial - startIdexOfMaterial);
                string coordinate = output.Substring(startIndexCoordinate, endIndexCoordinate - startIndexCoordinate);

                Console.WriteLine($"Found {material} at {coordinate}");

                input = Console.ReadLine();
            }
        }
    }
}
