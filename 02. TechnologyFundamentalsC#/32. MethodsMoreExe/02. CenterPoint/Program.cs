using System;

namespace centerPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            ClosestPointToCenter(x1, y1, x2, y2);
        }

        private static void ClosestPointToCenter(double x1, double y1, double x2, double y2)
        {
            double sumOfFirst = Math.Abs(x1) + Math.Abs(y1);
            double sumOfSecond = Math.Abs(x2) + Math.Abs(y2);
            if (sumOfFirst == sumOfSecond)
                Console.WriteLine($"({x1}, {y1})");
            else if(sumOfFirst<sumOfSecond)
                Console.WriteLine($"({x1}, {y1})");
            else
                Console.WriteLine($"({x2}, {y2})");
        }
    }
}
