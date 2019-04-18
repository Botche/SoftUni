using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace division
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int div = 0;
            if (num % 2 == 0)
                div = 2;
            if (num % 3 == 0)
                div = 3;
            if (num % 6 == 0)
                div = 6;
            if (num % 7 == 0)
                div = 7;
            if (num % 10 == 0)
                div = 10;
            if (div == 0)
                Console.WriteLine("Not divisible");
            else
                Console.WriteLine($"The number is divisible by {div}");
        }
    }
}
