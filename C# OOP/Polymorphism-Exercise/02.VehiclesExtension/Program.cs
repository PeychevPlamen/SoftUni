using System;

namespace _02.VehiclesExtension
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            double carFuel = double.Parse(carData[1]);
            double carLitersPerKm = double.Parse(carData[2]);
            double carTankCapacity = double.Parse(carData[3]);

            Vehicle car = new Car(carFuel, carLitersPerKm, carTankCapacity);

            string[] truckData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            double truckFuel = double.Parse(truckData[1]);
            double truckLitersPerKm = double.Parse(truckData[2]);
            double truckTankCapacity = double.Parse(truckData[3]);

            Vehicle truck = new Truck(truckFuel, truckLitersPerKm, truckTankCapacity);

            string [] busData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            double busFuel = double.Parse(busData[1]);
            double busLitersPerKm = double.Parse(busData[2]);
            double busTankCapacity = double.Parse(busData[3]);

            Vehicle bus = new Bus(busFuel, busLitersPerKm, busTankCapacity);

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
                        if (vehicle == "Bus")
                        {
                            ((Bus)bus).TurnOnAirConditioner();
                            bus.Driven(distance);
                        }

                        Console.WriteLine($"{vehicle} travelled {distance} km");
                    }
                    if (currCmd == "DriveEmpty")
                    {
                        double distance = double.Parse(inputCmd[2]);

                        ((Bus)bus).TurnOffAirConditioner();
                        bus.Driven(distance);

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
                        if (vehicle == "Bus")
                        {
                            bus.Refuel(liters);
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
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
