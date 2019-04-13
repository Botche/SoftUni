using System;

namespace weddingDecoration
{
    class Program
    {
        static void Main()
        {
            double budjet = double.Parse(Console.ReadLine());
            double sum = 0;
            int counterB=0, counterF = 0, counterC = 0, counter = 0;
            while(true)
            {
                string stock = Console.ReadLine();
                if (stock == "stop")
                {
                    Console.WriteLine($"Spend money: {sum:f2}");
                    Console.WriteLine($"Money left: {budjet-sum:f2}");
                    break;
                }
                int br = int.Parse(Console.ReadLine());
                if (stock == "balloons")
                {
                    counterB += br; 
                    sum = sum + br * 0.1;
                }
                else if (stock == "flowers")
                {
                    counterF += br;
                    sum = sum + br * 1.5;
                }
                else if (stock == "candles")
                {
                    counterC += br;
                    sum = sum + br * 0.5;
                }
                else if(stock== "ribbon")
                {
                    counter += br;
                    sum = sum + br * 2.0;
                }
                if(budjet<=sum)
                {
                    Console.WriteLine("All money is spent!");
                    break;
                }
            }
            Console.WriteLine($"Purchased decoration is {counterB} balloons, {counter} m ribbon, { counterF} flowers and {counterC} candles.");
        }
    }
}
