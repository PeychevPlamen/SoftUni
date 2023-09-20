using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses

{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumption;

        }
        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance { get; set; }

        public bool Drive(double distanceTraveled)
        {
            double neededFuel = distanceTraveled * FuelConsumptionPerKilometer;

            if (neededFuel > FuelAmount)
            {
                return false;
            }

            this.FuelAmount -= neededFuel;
            this.TravelledDistance += distanceTraveled;
            return true;
        }
    }
}
