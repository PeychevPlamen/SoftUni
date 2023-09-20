using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] currCar = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = currCar[0];
                double fuelAmount = double.Parse(currCar[1]);
                double FuelConsumptionPerKilometer = double.Parse(currCar[2]);

                Car car = new Car(model, fuelAmount, FuelConsumptionPerKilometer);
                cars.Add(car);
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string currCmd = command[0];
                string model = command[1];
                double distanceTraveled = double.Parse(command[2]);

                Car car = cars.FirstOrDefault(c => c.Model == model);

                bool isDrive = car.Drive(distanceTraveled);

                if (isDrive == false)
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
                
                input = Console.ReadLine();
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
