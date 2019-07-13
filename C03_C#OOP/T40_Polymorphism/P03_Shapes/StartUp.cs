using Shapes.Shapes;
using System;

namespace Shapes
{
    public class StartUp
    {
        public static void Main()
        {
            var rect = new Rectangle(4, 5);
            var circle = new Circle(3);

            PrintInfoForShape(rect);
            PrintInfoForShape(circle);
        }

        private static void PrintInfoForShape(Shape shape)
        {
            Console.WriteLine($"{shape.CalculatePerimeter():f2}");
            Console.WriteLine($"{shape.CalculateArea():f2}");
            Console.WriteLine(shape.Draw());
        }
    }
}
