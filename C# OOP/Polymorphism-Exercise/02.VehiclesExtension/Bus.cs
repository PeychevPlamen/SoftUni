using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double BusAirConditionModifier = 1.4;
        public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) 
            : base(fuelQuantity, fuelConsumptionPerKm, BusAirConditionModifier, tankCapacity)
        {

        }

        public void TurnOnAirConditioner()
        {
            AirConditionerModifier = BusAirConditionModifier;
        }

        public void TurnOffAirConditioner()
        {
            AirConditionerModifier = 0;
        }
    }
}
