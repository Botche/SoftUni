using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evenNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 1;
            while (true)
            {
                num = int.Parse(Console.ReadLine());
                if (Math.Abs(num) % 2 == 0)
                {
                    Console.WriteLine($"The number is: {Math.Abs(num)}");
                    break;
                }
                else
                    Console.WriteLine("Please write an even number.");
            }
        }
    }
}
