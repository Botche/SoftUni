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