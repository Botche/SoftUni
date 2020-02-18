using System;


namespace School_Supplies
{
    class Program
    {
        static void Main()
        {
            int brP = int.Parse(Console.ReadLine());
            int brM = int.Parse(Console.ReadLine());
            double L = double.Parse(Console.ReadLine());
            int pr = int.Parse(Console.ReadLine());
            double sum, sum1;
            sum = brP * 5.80 + brM * 7.20 + L * 1.20;
            sum1 = sum - sum * pr / 100;
            Console.WriteLine($"{sum1:f3}");
        }
    }
}
