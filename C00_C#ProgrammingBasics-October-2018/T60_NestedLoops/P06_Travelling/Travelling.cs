using System;

namespace travelling
{
    class Program
    {
        static void Main()
        {
            string place = Console.ReadLine();
            double n = double.Parse(Console.ReadLine());
            double sum = 0,money;
            while (true)
            {
                money = double.Parse(Console.ReadLine());
                sum += money;
                if (sum >= n)
                {
                    Console.WriteLine($"Going to {place}!");
                    sum = 0;
                    place = Console.ReadLine();
                    if (place == "End")
                        break;
                    n = double.Parse(Console.ReadLine());
                }
            }
        }
    }
}
