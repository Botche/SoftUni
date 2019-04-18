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

