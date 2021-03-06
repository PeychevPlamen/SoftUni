﻿using System;

namespace _05._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = string.Empty;

            for (int i = username.Length - 1; i >= 0; i--)
            {
                password += username[i];
            }

            int counter = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input != password)
                {
                    counter++;
                    if (counter == 4)
                    {
                        Console.WriteLine($"User {username} blocked!");
                        break;
                    }

                    Console.WriteLine("Incorrect password. Try again.");
                }
                
                else
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }
            }
            
        }
    }
}
