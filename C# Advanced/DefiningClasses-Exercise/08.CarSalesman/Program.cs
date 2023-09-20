using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<Engine> engines = new HashSet<Engine>();
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] inputEngine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = inputEngine[0];
                int power = int.Parse(inputEngine[1]);

                Engine engine = null;

                if (inputEngine.Length == 4)
                {
                    int displacement = int.Parse(inputEngine[2]);
                    string efficiency = inputEngine[3];

                    engine = new Engine(model, power, displacement, efficiency);

                }
                else if (inputEngine.Length == 2)
                {
                    engine = new Engine(model, power);

                }
                else if (inputEngine.Length == 3)
                {
                    int displacement;

                    bool isDisplacement = int.TryParse(inputEngine[2], out displacement);

                    if (isDisplacement)
                    {
                        engine = new Engine(model, power, displacement);
                    }
                    else
                    {
                        engine = new Engine(model, power, inputEngine[2]);
                    }

                }

                engines.Add(engine);


            }

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] inputCar = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Car car = null;

                string modelCar = inputCar[0];
                Engine engine = engines.First(e => e.Model == inputCar[1]);

                if (inputCar.Length == 2)
                {
                    car = new Car(modelCar, engine);
                }
                else if (inputCar.Length == 3)
                {
                    int weight;

                    bool isWeight = int.TryParse(inputCar[2], out weight);

                    if (isWeight)
                    {
                        car = new Car(modelCar, engine, weight);
                    }
                    else
                    {
                        car = new Car(modelCar, engine, inputCar[2]);
                    }
                }
                else if (inputCar.Length == 4)
                {
                    car = new Car(modelCar, engine, int.Parse(inputCar[2]), inputCar[3]);
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
