using System;

namespace mathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            int pow = int.Parse(Console.ReadLine());

            Console.WriteLine(PowThatNumber(num, pow));
        }

        private static double PowThatNumber(double num, int pow)
        {
            return Math.Pow(num, pow);
        }
    }
}
