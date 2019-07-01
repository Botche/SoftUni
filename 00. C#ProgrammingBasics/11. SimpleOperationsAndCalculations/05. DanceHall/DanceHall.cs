using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            double l = double.Parse(Console.ReadLine());
            double w = double.Parse(Console.ReadLine());
            double a = double.Parse(Console.ReadLine());
            double s, g, p, sv, br;
            s = (l * 100) * (w * 100);
            g = (a * 100)*(a * 100);
            p = s / 10;
            sv = s - p - g;
            br = sv / (40 + 7000);
            Console.WriteLine(Math.Floor(br));
        }
    }
}