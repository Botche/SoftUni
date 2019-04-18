using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main()
        {
            double whis = double.Parse(Console.ReadLine());
            double beer = double.Parse(Console.ReadLine());
            double wine = double.Parse(Console.ReadLine());
            double rakia = double.Parse(Console.ReadLine());
            double whisk = double.Parse(Console.ReadLine());
            double sumr, sumwi, sumb, sum;
            sumr = whis / 2;
            sumwi = sumr-(0.4*sumr);
            sumb = sumr - (0.8 * sumr);
            sumr = sumr * rakia;
            whis = whis * whisk;
            sumb = sumb * beer;
            sumwi = sumwi * wine;
            sum = sumwi + whis + sumb + sumr;
            Console.WriteLine($"{sum:f2}");
        }
    }
}
