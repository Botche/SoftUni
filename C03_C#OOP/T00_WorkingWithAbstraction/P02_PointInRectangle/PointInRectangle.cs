using System;
using System.Linq;

namespace _02._PointInRectangle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] rectanglePoints = ParseInput();

            Point firstPoint = new Point(rectanglePoints[0], rectanglePoints[1]);
            Point secondPoint = new Point(rectanglePoints[2], rectanglePoints[3]);

            Rectangle rectangle = new Rectangle(firstPoint, secondPoint);

            int countOfPointsToCheck = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfPointsToCheck; i++)
            {
                int[] coordinatesOfPoint = ParseInput();

                Point point = new Point(coordinatesOfPoint[0], coordinatesOfPoint[1]);

                Console.WriteLine(rectangle.Contains(point));
            }
        }

        private static int[] ParseInput()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
