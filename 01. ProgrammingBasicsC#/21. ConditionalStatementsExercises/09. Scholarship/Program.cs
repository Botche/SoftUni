using System;

namespace scholarship
{
    class Program
    {
        static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double step,stepg;
            step = c * 0.35;
            stepg = b * 25;
            if(b>=4.5 && b<5.5 && a<c)
                Console.WriteLine($"You get a Social scholarship {Math.Floor(step)} BGN");
            else if (b>=5.5)
            {
                if(a<c)
                {
                    if (step <= stepg)
                        Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(stepg)} BGN");
                    else
                        Console.WriteLine($"You get a Social scholarship {Math.Floor(step)} BGN");
                }
                else
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(stepg)} BGN");
            }
            else 
                Console.WriteLine("You cannot get a scholarship!");
            Console.ReadKey();
        }
    }
}
