using System;

namespace calculateRentacgularArea
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            Console.WriteLine(ReturnTheRectangularArea(width,height));
        }

        private static int ReturnTheRectangularArea(int width, int height)
        {
            int sum = width * height;
            return sum;
        }
    }
}
