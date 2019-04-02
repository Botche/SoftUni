using System;

namespace speedInfo
{
    class Program
    {
        static void Main()
        {
            double v = double.Parse(Console.ReadLine());
            if(v<=10)
                Console.WriteLine("slow");
            else if(v > 10 && v <= 50)
                  Console.WriteLine("average");
            else if (v > 50 && v <= 150)
                Console.WriteLine("fast");
            else if (v > 150 && v <= 1000)
                Console.WriteLine("ultra fast");
            else if (v > 1000)
                Console.WriteLine("extremely fast");


        }
    }
}
