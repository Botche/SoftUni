using System;

namespace rightAndLeftSum
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int sum1 = 0, sum2 = 0;
            for (var i = 0; i < 2 * n; i++)
            {
                int a = int.Parse(Console.ReadLine());
                if (i < n)
                {
                    sum1 += a;
                }
                else
                    sum2 += a;

            }
            if(sum1==sum2)
            {
                Console.WriteLine($"Yes, sum = {sum1}");
            }
            else
                Console.WriteLine($"No, diff = {Math.Abs(sum1-sum2)}");
        }
    }
}
