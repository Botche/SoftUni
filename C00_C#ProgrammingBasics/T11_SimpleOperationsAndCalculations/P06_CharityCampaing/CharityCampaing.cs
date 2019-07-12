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
            int days = int.Parse(Console.ReadLine());
            int pr = int.Parse(Console.ReadLine());
            int cake = int.Parse(Console.ReadLine());
            int gof = int.Parse(Console.ReadLine());
            int pal = int.Parse(Console.ReadLine());
            double cakes, gofs, pals, sum1, sum2,sum3 ;
            cakes = cake * 45;
            gofs = gof * 5.80;
            pals = pal * 3.20;
            sum1 = (cakes + pals + gofs) * pr;
            sum2 = sum1 * days;
            sum3 = sum2 - (0.125 * sum2);
            Console.WriteLine("{0:0.00}",sum3);
        }
    }
}
