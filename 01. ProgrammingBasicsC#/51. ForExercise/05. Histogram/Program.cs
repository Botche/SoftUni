using System;
namespace histogram
{
    class Program
    {
        static void Main()
        {
            double n = double.Parse(Console.ReadLine());
            double counter1 = 0, counter2 = 0, counter3 = 0, counter4 = 0, counter5 = 0;
            for (var i=0;i<n;i++)
            {
                double a = double.Parse(Console.ReadLine());
                if (a < 200)
                {
                    counter1++;
                }
                else if (a >= 200 && a < 400)
                    counter2++;
                else if (a >= 400 && a < 600)
                    counter3++;
                else if (a >= 600 && a < 800)
                    counter4++;
                else if (a >= 800)
                    counter5++;
            }
            double sum = counter1 / n;
            if (counter1 == 0)
                Console.WriteLine("0.00");
            else
                Console.WriteLine($"{sum * 100:f2}");
            sum = counter2 / n;
            if (counter2 == 0)
                Console.WriteLine("0.00");
            else
                Console.WriteLine($"{sum * 100:f2}");
            sum = counter3 / n;
            if (counter3 == 0)
                Console.WriteLine("0.00");
            else
                Console.WriteLine($"{sum * 100:f2}");
            sum = counter4 / n;
            if (counter4 == 0)
                Console.WriteLine("0.00");
            else
                Console.WriteLine($"{sum * 100:f2}");
            sum = counter5 / n;
            if (counter5 == 0)
                Console.WriteLine("0.00");
            else
                Console.WriteLine($"{sum * 100:f2}");
            
        }
    }
}
