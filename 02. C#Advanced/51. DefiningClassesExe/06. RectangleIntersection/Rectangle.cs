using System;
using System.Collections.Generic;
using System.Text;

namespace _06._RectangleIntersection
{
    class Rectangle
    {
        private string id;
        private int width;
        private int heigth;
        private int coordinatesHorizontal;
        private int coordinatesVertical;

        public string Id { get => id;}
        public Rectangle(string id, int width, int heigth, int coordinatesHorizontal, int coordinatesVertical)
        {
            this.id = id;
            this.width = width;
            this.heigth = heigth;
            this.coordinatesHorizontal = coordinatesHorizontal;
            this.coordinatesVertical = coordinatesVertical;
        }

        public bool IsThereIntersect(Rectangle rectangle)
        {
            bool havingIntersect = false;
            int x1 = coordinatesHorizontal;
            int x2 = coordinatesHorizontal + width;

            int y1 = coordinatesVertical;
            int y2 = coordinatesVertical + heigth;

            int recX1 = rectangle.coordinatesHorizontal;
            int recX2 = rectangle.coordinatesHorizontal + width;

            int recY1 = rectangle.coordinatesVertical;
            int recY2 = rectangle.coordinatesVertical + heigth;

            if ((recX1 >= x1 && recX1 <= x2) || (recY1 >= y1 && recY1 <= y2))
            {
                havingIntersect = true;
            }
            if ((recX2 >= x1 && recX2 <= x2) || (recY2 >= y1 && recY2 <= y2))
            {
                havingIntersect = true;
            }

            return havingIntersect;
        }

    }
}
