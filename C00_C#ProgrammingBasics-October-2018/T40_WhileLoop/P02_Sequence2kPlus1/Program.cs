using System;

namespace sequence2kplus1
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = 1;
            while(k<=n)
            {
                Console.WriteLine(k);
                k = 2*k + 1;
            }
        }
    }
}
