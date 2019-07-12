using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._RectangleIntersection
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] constraits = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();
            List<Rectangle> rectangles = new List<Rectangle>();
            for (int i = 0; i < constraits[0]; i++)
            {
                string[] rectangleInfo = Console.ReadLine()
                    .Split();
                string id = rectangleInfo[0];
                int width = int.Parse(rectangleInfo[1]);
                int heigth = int.Parse(rectangleInfo[2]);
                int horizontal = int.Parse(rectangleInfo[3]);
                int vertical = int.Parse(rectangleInfo[4]);

                Rectangle rectangle = new Rectangle(id, width, heigth, horizontal, vertical);

                rectangles.Add(rectangle);
            }

            string[] rectanglesToCompare = Console.ReadLine()
                .Split();

            Rectangle rectangle1 = rectangles.Find(x => x.Id == rectanglesToCompare[0]);

            Rectangle rectangle2 = rectangles.Find(x => x.Id == rectanglesToCompare[1]);

            Console.WriteLine(rectangle1.IsThereIntersect(rectangle2));
        }
    }
}
