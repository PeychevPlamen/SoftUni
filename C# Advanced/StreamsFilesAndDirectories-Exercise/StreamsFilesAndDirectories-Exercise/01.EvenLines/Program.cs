using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../../output.txt"))
                {
                    string line = reader.ReadLine();
                    int lineCounter = 0;
                    string pattern = @"[-,.!?]";

                    while (line != null)
                    {
                        if (lineCounter % 2 == 0)
                        {
                            Regex regex = new Regex(pattern);
                            line = regex.Replace(line, "@");

                            string[] reversed = line.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                 .ToArray();

                            Array.Reverse(reversed);

                            writer.WriteLine(string.Join(" ", reversed));
                        }
                        lineCounter++;
                        line = reader.ReadLine();
                    }
                }

            }
        }
    }
}
