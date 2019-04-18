using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main()
        {
            int br = int.Parse(Console.ReadLine());
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double bgn, usd, area1, area2;
            area1 = br * (a + 2 * 0.30) * (b + 2 * 0.30);
            area2 = br * (a / 2) * (a / 2);
            usd = area1 * 7 + area2 * 9;
            bgn = usd * 1.85;
            Console.WriteLine($"{usd:f2}"+ " USD");
            Console.WriteLine($"{bgn:f2}" + " BGN");

        }
    }
}
