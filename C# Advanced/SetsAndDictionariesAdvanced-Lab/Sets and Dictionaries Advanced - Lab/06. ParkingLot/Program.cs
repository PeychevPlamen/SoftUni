using System;
using System.Collections.Generic;

namespace _06._ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            HashSet<string> cars = new HashSet<string>();

            while (input != "END")
            {
                string[] tokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                string carNumber = tokens[1];

                if (command == "IN")
                {
                    cars.Add(carNumber);
                }
                else
                {
                    cars.Remove(carNumber);
                }

                input = Console.ReadLine();
            }
            if (cars.Count > 0)
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            
        }
    }
}
