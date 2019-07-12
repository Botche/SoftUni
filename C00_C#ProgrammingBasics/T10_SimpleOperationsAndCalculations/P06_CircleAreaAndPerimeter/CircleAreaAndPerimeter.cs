using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());
            double area = Math.PI * r * r;
            double perimetur = 2 * Math.PI * r;
            Console.Write("Area = ");
            Console.Write(area);
            Console.WriteLine();
            Console.Write("Perimetur = ");
            Console.Write(perimetur);
            Console.WriteLine();

        }
    }
}