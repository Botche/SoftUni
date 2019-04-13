using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Radians_to_Degrees
{
    class Program
    {
        static void Main(string[] args)
        {
            double rad = 57.29578;
            double radians = double.Parse(Console.ReadLine());
            Console.WriteLine("{0:f2}",radians * rad);
        }
    }
}