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
            double cel = double.Parse(Console.ReadLine());
            double far;
            far = cel * 1.8 + 32;
            Console.Write(Math.Round(far,2) + Environment.NewLine);
           
        }
    }
}
