using System;

namespace schoolTrip
{
    class Program
    {
        static void Main()
        {
            int brD = int.Parse(Console.ReadLine());
            int kgF = int.Parse(Console.ReadLine());
            double d1 = double.Parse(Console.ReadLine());
            double d2 = double.Parse(Console.ReadLine());
            double d3 = double.Parse(Console.ReadLine());
            double sumAll;
            sumAll = (d1 + d2 + d3) * brD;
            if(sumAll<=kgF)
                Console.WriteLine($"{Math.Floor(kgF-sumAll)} kilos of food left.");
            else
                Console.WriteLine($"{Math.Ceiling(sumAll-kgF)} more kilos of food are needed.");
        }
    }
}
