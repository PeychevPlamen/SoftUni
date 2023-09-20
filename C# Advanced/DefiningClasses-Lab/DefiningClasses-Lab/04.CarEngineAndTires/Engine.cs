using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Engine
    {
        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }
        private int horsePower;
        private double cubicCapacity;

        private int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }
        private double CubicCapacity
        {
            get { return cubicCapacity; }
            set { cubicCapacity = value; }
        }
    }
}
