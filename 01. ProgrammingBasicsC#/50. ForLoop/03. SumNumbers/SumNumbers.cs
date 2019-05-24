using System;

namespace sumNumbers
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            for(var i=0;i<n;i++)
            {
                int a = int.Parse(Console.ReadLine());
                sum += a;
            }
            Console.WriteLine(sum);
        }
    }
}
