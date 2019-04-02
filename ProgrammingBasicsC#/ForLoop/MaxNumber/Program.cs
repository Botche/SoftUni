using System;

namespace maxNumber
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int max=int.MinValue;
            for(var i=0;i<n;i++)
            {
                int a = int.Parse(Console.ReadLine());
                if (max < a)
                    max = a;
            }
            Console.WriteLine(max);
        }
    }
}
