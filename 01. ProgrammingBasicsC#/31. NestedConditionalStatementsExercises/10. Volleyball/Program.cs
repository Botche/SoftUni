using System;

namespace volleyball
{
    class Program
    {
        static void Main()
        {
            string year = Console.ReadLine();
            double p = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            double all,h1,p1;
            h1 = (48 - h) * 0.75;
            p1 = p *(2.0/3.0);
            all = h1 + h + p1;
            if(year=="leap")
            {
                all = all + all * 0.15;
            }
            Console.WriteLine(Math.Truncate(all));
        }
    }
}
