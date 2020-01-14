using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height
        {
            get => height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be a null or negative.");
                }
                height = value;
            }
        }
        public double Width
        {
            get => width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be a null or negative.");
                }
                width = value;
            }
        }

        public override double CalculateArea()
        {
            double area = Width * Height;

            return area;
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * (Width + Height);

            return perimeter;
        }

        public override string Draw()
        {
            return base.Draw() + "Rectangle";
        }
    }
}
