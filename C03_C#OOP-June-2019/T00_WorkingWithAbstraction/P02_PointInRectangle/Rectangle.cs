using System;
using System.Collections.Generic;
using System.Text;

namespace _02._PointInRectangle
{
    public class Rectangle
    {
        public Rectangle(Point firstPoint, Point secondPoint)
        {
            FirstPoint = firstPoint;
            SecondPoint = secondPoint;
        }

        public Point FirstPoint { get; private set; }
        public Point SecondPoint { get; private set; }

        public bool Contains(Point point)
        {
            bool isContained = false;

            if (point.X>=FirstPoint.X && point.X<=SecondPoint.X
                && point.Y>=FirstPoint.Y && point.Y<=SecondPoint.Y)
            {
                isContained = true;
            }

            return isContained;
        }
    }
}
