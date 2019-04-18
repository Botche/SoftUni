using System;

namespace cinema
{
    class Program
    {
        static void Main()
        {
            string type = Console.ReadLine();
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            double sum=0;
            if (type == "Premiere")
                sum = c * r * 12;
            else if (type == "Normal")
                sum = c * r * 7.50;
            else if (type == "Discount")
                sum = c * r * 5.00;
            Console.WriteLine($"{sum:f2}"); 
        }
    }
}
