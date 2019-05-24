using System;

namespace equalPairs
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int sum1 = 0, sum2 = 0, sum3 = int.MinValue, max = int.MinValue;
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            sum1 = a + b;
            for (var i=1;i<n;i++)
            {
                int c = int.Parse(Console.ReadLine());
                int d = int.Parse(Console.ReadLine());
                sum2 = c + d;

                if (sum2 - sum1 != 0)
                    sum3 = Math.Abs(sum2 - sum1);

                sum1 = sum2;

                if (sum3 > max)
                    max = sum3;
            }
            if(sum3== int.MinValue)
                Console.WriteLine($"Yes, value={sum1}");
            else
                Console.WriteLine($"No, maxdiff={max}");
        }
    }
}
