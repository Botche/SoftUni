using System;


namespace ConsoleApp2
{
    class Program
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());

            while (a < 9 || a > 501)
            { a = int.Parse(Console.ReadLine()); }

            int b = int.Parse(Console.ReadLine());

            while (b < 9 || b > 301)
            { b = int.Parse(Console.ReadLine()); }

            int h = int.Parse(Console.ReadLine());

            while (h < 9 || h > 201)
            { h = int.Parse(Console.ReadLine()); }

            double pr = double.Parse(Console.ReadLine());

            while (pr <= 0.000 || pr >= 100.000)
            { pr = double.Parse(Console.ReadLine()); }

            double v,l,pr1,litres;
            pr1 = pr * 0.01; 
            v = a * b * h;
            l = v * 0.001;
            litres = l * (1 - pr1);
            Console.WriteLine("{0:F3}",litres);
        }
    }
}