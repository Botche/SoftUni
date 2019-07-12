using System;

namespace pokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int counter = 0;
            int originalN = n;
            while(n>=m)
            {
                n -= m;
                counter++;
                if (n == (originalN/2))
                {
                   if( y!=0)
                        n/=y;
                }
            }
            Console.WriteLine(n);
            Console.WriteLine(counter);
        }
    }
}
