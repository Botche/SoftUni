using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius
        {
            get=>radius;
            set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Radius cannot be a null or negative.");
                }
                radius = value;
            }
        }

        public override double CalculateArea()
        {
            double area = Math.PI * Math.Pow(radius, 2);

            return area;
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * Math.PI * radius;

            return perimeter;
        }

        public override string Draw()
        {
            return base.Draw() + "Circle";
        }
    }
}
