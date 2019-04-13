using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace everest
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            int km = 0,counterD=1,sum=5364;
            while(true)
            {
                command = Console.ReadLine();
                if (command == "END")
                {
                    Console.WriteLine("Failed!");
                    Console.WriteLine(sum);
                    break;
                }
                else if (command == "Yes")
                    counterD++;
                if (counterD > 5)
                {
                    Console.WriteLine("Failed!");
                    Console.WriteLine(sum);
                    break;
                }
                km = int.Parse(Console.ReadLine());
                sum += km;
                if (sum >= 8848)
                {
                    Console.WriteLine($"Goal reached for {counterD} days!");
                    break;
                }
                
            }
        }
    }
}
