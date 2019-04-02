using System;

namespace maxNumber
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int min = int.MaxValue;
            for (var i = 0; i < n; i++)
            {
                int a = int.Parse(Console.ReadLine());
                if (min > a)
                    min = a;
            }
            Console.WriteLine(min);
        }
    }
}
