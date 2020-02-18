using System;

namespace energyBooster
{
    class Program
    {
        static void Main()
        {
            string fruit = Console.ReadLine();
            string vid = Console.ReadLine();
            int br = int.Parse(Console.ReadLine());
            double sum = 0;
            if (vid == "small")
            {
                if (fruit == "Watermelon")
                    sum = (2 * 56) * br;
                else if (fruit == "Mango")
                    sum = (2 * 36.66) * br;
                else if (fruit == "Pineapple")
                    sum = (2 * 42.10) * br;
                else
                    sum = (2 * 20) * br;
            }
            else
            {
                if (fruit == "Watermelon")
                    sum = (5 * 28.70) * br;
                else if (fruit == "Mango")
                    sum = (5 * 19.60) * br;
                else if (fruit == "Pineapple")
                    sum = (5 * 24.80) * br;
                else
                    sum = (5 * 15.20) * br;
            }
            if (sum <= 1000 && sum >= 400)
            {
                sum -= sum * 0.15;
            }
            else if(sum>1000)
                sum -= sum * 0.50;
            Console.WriteLine($"{sum:f2} lv.");
        }
    }
}
