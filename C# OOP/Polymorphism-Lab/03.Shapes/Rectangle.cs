using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height { get; private set; }

        public double Width { get; private set; }


        public override double CalculateArea()
        {
            double result = Height * Width;

            return result;
        }

        public override double CalculatePerimeter()
        {
            double result = 2 * Height + 2 * Width;

            return result;
        }
        public override string Draw()
        {
            return $"{base.Draw()} {GetType().Name}";
        }

    }
}
