using System;

namespace csg
{
    class Program
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int csg=1;
            if (a == b)
                Console.WriteLine(a);
            else
            {
                for (var i = b; i >= 1; i--)
                {
                    if (a % i == 0 && b % i == 0)
                    { csg = i; break; }
                }
                Console.WriteLine(csg);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace nonEuclidisGCD
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            int smaller = Math.Min(n, m);
            int greater = Math.Max(n, m);
            int difference = greater - smaller;
            int iterator = Math.Min(difference, smaller);
            int oldDivisor = 1;
            int newDivisor = 1;

            for (int i = 1; i <= iterator; i++)
            {
                if (difference % i == 0 && smaller % i == 0)
                {
                    newDivisor = i;
                }
                if (newDivisor > oldDivisor)
                {
                    oldDivisor = newDivisor;
                }

            }

            Console.WriteLine(n == m ? n : oldDivisor);
        }
    }
}
