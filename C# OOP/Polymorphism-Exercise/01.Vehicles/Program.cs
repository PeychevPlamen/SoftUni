using System;

namespace _01.Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            double carFuel = double.Parse(carData[1]);
            double carLitersPerKm = double.Parse(carData[2]);

            Vehicle car = new Car(carFuel, carLitersPerKm);

            string[] truckData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            double truckFuel = double.Parse(truckData[1]);
            double truckLitersPerKm = double.Parse(truckData[2]);

            Vehicle truck = new Truck(truckFuel, truckLitersPerKm);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputCmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string currCmd = inputCmd[0];
                string vehicle = inputCmd[1];
                try
                {
                    if (currCmd == "Drive")
                    {
                        double distance = double.Parse(inputCmd[2]);

                        if (vehicle == "Car")
                        {
                            car.Driven(distance);
                        }
                        if (vehicle == "Truck")
                        {
                            truck.Driven(distance);
                        }

                        Console.WriteLine($"{vehicle} travelled {distance} km");
                    }
                    else if (currCmd == "Refuel")
                    {
                        double liters = double.Parse(inputCmd[2]);

                        if (vehicle == "Car")
                        {
                            car.Refuel(liters);
                        }
                        if (vehicle == "Truck")
                        {
                            truck.Refuel(liters);
                        }
                    }
                                        
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");

        }
    }
}
