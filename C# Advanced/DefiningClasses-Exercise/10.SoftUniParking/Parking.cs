using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public int Count => this.cars.Count;
        //{
        //    get { return this.cars.Count; }

        //}

        public Parking(int capacity)
        {
            this.cars = new List<Car>();
            this.capacity = capacity;
        }

        public string AddCar(Car car)
        {
            if (this.cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            if (this.cars.Count == this.capacity)
            {
                return "Parking is full!";
            }
            else
            {
                this.cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }

        }

        public string RemoveCar(string registrationNumber)
        {
            Car car = this.cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);

            if (car == null)
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                cars.Remove(car);

                return $"Successfully removed {registrationNumber}";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            Car car = this.cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);

            return car;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            this.cars = cars.Where(c => !registrationNumbers.Contains(c.RegistrationNumber)).ToList();
        }

    }
}
