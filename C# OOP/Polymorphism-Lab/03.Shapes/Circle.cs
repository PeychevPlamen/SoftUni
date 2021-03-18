using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius { get; private set; }

        public override double CalculateArea()
        {
            double result = (Math.PI * Radius * Radius);

            return result;
        }

        public override double CalculatePerimeter()
        {
            double result = Math.PI * 2 * Radius;

            return result;
        }
        public override string Draw()
        {
            return $"{base.Draw()} {GetType().Name}";
        }
    }
}
