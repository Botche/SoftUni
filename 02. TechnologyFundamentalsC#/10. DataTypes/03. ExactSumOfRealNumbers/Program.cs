using System;

namespace exactSumOfRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            decimal sum=0m;
            for(int i=0;i<n;i++)
            {
                double num = double.Parse(Console.ReadLine());
                sum +=(decimal)num ;
            }
            Console.WriteLine(sum);
        }
    }
}
