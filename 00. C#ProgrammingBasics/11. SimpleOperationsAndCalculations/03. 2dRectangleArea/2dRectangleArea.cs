using System;

namespace LicePravougulnik
{
    class Program
    {
        static void Main()
        {
            var x1 = double.Parse(Console.ReadLine());
            var y1 = double.Parse(Console.ReadLine());

            var x2 = double.Parse(Console.ReadLine());
            var y2 = double.Parse(Console.ReadLine());

            double S,P;
            S = Math.Abs(x2 - x1) * Math.Abs(y2 - y1);
            P= (Math.Abs(x2 - x1) + Math.Abs(y2 - y1))*2;
            Console.WriteLine("S= " + S);
            Console.WriteLine("P= " + P);
        }
    }
}
