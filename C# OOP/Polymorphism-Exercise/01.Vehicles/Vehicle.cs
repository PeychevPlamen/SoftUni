using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double airConditionerModifier)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
            AirConditionerModifier = airConditionerModifier;

        }
        private double AirConditionerModifier { get; set; }

        public double FuelQuantity { get; private set; }

        public double FuelConsumptionPerKm { get; private set; }

        public void Driven(double distance)
        {
            double requiredFuel = (FuelConsumptionPerKm + AirConditionerModifier)* distance;

            if (FuelQuantity < requiredFuel)
            {
                throw new InvalidOperationException($"{GetType().Name} needs refueling");
            }

            FuelQuantity -= requiredFuel;
        }

        public virtual void Refuel(double amount)
        {
            FuelQuantity += amount;
        }
    }
}
