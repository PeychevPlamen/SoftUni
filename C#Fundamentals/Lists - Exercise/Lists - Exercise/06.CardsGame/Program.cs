using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayer = Console.ReadLine()
                                           .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                           .Select(int.Parse)
                                           .ToList();

            List<int> secondPlayer = Console.ReadLine()
                                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToList();

            while (firstPlayer.Count != 0 && secondPlayer.Count != 0)
            {
                int firstCard = firstPlayer[0];
                int secondCard = secondPlayer[0];

                if (firstCard > secondCard)
                {
                    firstPlayer.Add(firstCard);
                    firstPlayer.Add(secondCard);
                    firstPlayer.RemoveAt(0);
                    secondPlayer.RemoveAt(0);
                }
                else if (firstCard < secondCard)
                {
                    secondPlayer.Add(secondCard);
                    secondPlayer.Add(firstCard);
                    secondPlayer.RemoveAt(0);
                    firstPlayer.RemoveAt(0);
                }
                else
                {
                    firstPlayer.RemoveAt(0);
                    secondPlayer.RemoveAt(0);
                }
            }
            if (firstPlayer.Count > 0)
            {
                int sum = firstPlayer.Sum();
                Console.WriteLine($"First player wins! Sum: {sum}");
            }
            else
            {
                int sum = secondPlayer.Sum();
                Console.WriteLine($"Second player wins! Sum: {sum}");
            }
            
        }
    }
}
