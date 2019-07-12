using System;

namespace spaceship
{
    class Program
    {
        static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            double aveH = double.Parse(Console.ReadLine());
            double V, V1, br;
            V = a * b * h;
            V1 = 2 * 2 * (aveH + 0.40);
            br = V / V1;
            if (br >= 3 && br <= 10)
                Console.WriteLine($"The spacecraft holds {Math.Floor(br)} astronauts.");
            else if (br < 3)
                Console.WriteLine("The spacecraft is too small.");
            else
                Console.WriteLine("The spacecraft is too big.");
        }
    }
}
