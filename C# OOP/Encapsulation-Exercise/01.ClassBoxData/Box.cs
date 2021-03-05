using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;

            private set
            {
                ThrowIfInvalidSide(value, nameof(this.Length));

                this.length = value;
            }
        }

        public double Width
        {
            get => this.width;

            private set
            {
                ThrowIfInvalidSide(value, nameof(this.Width));

                this.width = value;
            }
        }


        public double Height
        {
            get => this.height;

            private set
            {
                ThrowIfInvalidSide(value, nameof(this.Height));

                this.height = value;
            }
        }

        public double SurfaceArea()
        {
            // 2lw + 2lh + 2wh

            double surfaceArea = 2 * (this.Length * this.Width) + 2 * (this.Length * this.Height) + 2 * (this.Width * this.Height);

            return surfaceArea;

        }

        public double LateralSurfaceArea()
        {
            // Lateral Surface Area = 2lh + 2wh

            double lateralSurfaceArea = 2 * (this.Length * this.Height) + 2 * (this.Width * this.Height);

            return lateralSurfaceArea;

        }

        public double Volume()
        {
            // Volume = lwh

            double volume = this.Length * this.Width * this.Height;

            return volume;
        }
        private void ThrowIfInvalidSide(double value, string side)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{side} cannot be zero or negative.");
            }
        }
    }
}
