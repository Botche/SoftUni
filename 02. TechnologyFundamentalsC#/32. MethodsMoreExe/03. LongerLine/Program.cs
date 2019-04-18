using System;

namespace centerPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            double x11 = double.Parse(Console.ReadLine());
            double y11 = double.Parse(Console.ReadLine());
            double x12 = double.Parse(Console.ReadLine());
            double y12 = double.Parse(Console.ReadLine());
            double x21 = double.Parse(Console.ReadLine());
            double y21 = double.Parse(Console.ReadLine());
            double x22 = double.Parse(Console.ReadLine());
            double y22 = double.Parse(Console.ReadLine());
            bool b=LongestLine(x11, y11, x12, y12, x21, y21, x22, y22);
            if (b == true)
                ClosestPointToCenter(x11, y11, x12, y12);
            else
                ClosestPointToCenter(x21, y21, x22, y22);
        }

        private static bool LongestLine(double x11, double y11, double x12, double y12, double x21, double y21, double x22, double y22)
        {
            double sumOfFirst = Math.Abs(x11) + Math.Abs(y11)+ Math.Abs(x12) + Math.Abs(y12);
            double sumOfSecond = Math.Abs(x21) + Math.Abs(y21) + Math.Abs(x22) + Math.Abs(y22);
            if (sumOfFirst == sumOfSecond)
                return true;
            else if (sumOfFirst > sumOfSecond)
                return true;
            else
                return false;
        }

        private static void ClosestPointToCenter(double x1, double y1, double x2, double y2)
        {
            double sumOfFirst = Math.Abs(x1) + Math.Abs(y1);
            double sumOfSecond = Math.Abs(x2) + Math.Abs(y2);
            if (sumOfFirst == sumOfSecond)
                Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
            else if (sumOfFirst < sumOfSecond)
                Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
            else
                Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
        }
    }
}
