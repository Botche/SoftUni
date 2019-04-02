using System;

namespace seaTrip
{
    class Program
    {
        static void Main()
        {
            double sumF = double.Parse(Console.ReadLine());
            double sumS = double.Parse(Console.ReadLine());
            double sumH = double.Parse(Console.ReadLine());
            double sumAll, sumT, sumA, sumHA;
            sumA = (sumS + sumF)*3;
            sumT = 29.4 * 1.85;
            sumHA = (sumH * 0.90) + (sumH * 0.85) + (sumH * 0.80);
            sumAll = sumA + sumT + sumHA;
            Console.WriteLine($"Money needed: {sumAll:f2}");

        }
    }
}
