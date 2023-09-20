using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Tire[] tires = new Tire[4]
            {
                new Tire(2002, 2.2),
                new Tire(2002, 2.1),
                new Tire(2006, 1.8),
                new Tire(2006, 1.9),
            };

            Engine engine = new Engine(170, 2000);

            Car car = new Car("BMW", "320", 2009, 55, 9, engine, tires);

            foreach (var tire in car.Tires)
            {
                Console.WriteLine($"{tire.Year} {tire.Pressure}");
            }

        }
    }
}
