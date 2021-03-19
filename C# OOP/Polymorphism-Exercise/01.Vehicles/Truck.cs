using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        private const double TruckAirConditionerModfier = 1.6;

        public Truck(double fuelQuantity, double fuelConsumptionPerKm) 
            : base(fuelQuantity, fuelConsumptionPerKm, TruckAirConditionerModfier)
        {

        }

        public override void Refuel(double amount)
        {
            base.Refuel(amount * 0.95);
        }
       
    }
}
