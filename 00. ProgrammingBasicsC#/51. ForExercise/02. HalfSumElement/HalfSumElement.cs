using System;

namespace halfSumElement
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int max = int.MinValue;
            int sum = 0;
            for(var i=0;i<n;i++)
            {
                int a = int.Parse(Console.ReadLine());
                if (max < a)
                    max = a; 
                sum += a;
            }
            if((sum-max)==max)
                Console.WriteLine($"Yes Sum = {max}");
            else
                Console.WriteLine($"No Diff = {Math.Abs(max-Math.Abs(max-sum))}");
        }
    }
}
