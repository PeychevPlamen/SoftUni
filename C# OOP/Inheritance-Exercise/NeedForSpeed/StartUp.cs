using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Vehicle vehicle = new Vehicle(150, 99);
            SportCar car = new SportCar(500, 200);

            vehicle.Drive(50);
            car.Drive(10);

            Console.WriteLine(vehicle.Fuel);
            Console.WriteLine(car.HorsePower);
            Console.WriteLine(car.Fuel);
            Console.WriteLine(car.GetType().Name);
            Console.WriteLine($"{car.GetType().Name}, with {car.HorsePower}Hp, {car.FuelConsumption} fuel consumption, {car.Fuel} fuel left");
        }
    }
}
