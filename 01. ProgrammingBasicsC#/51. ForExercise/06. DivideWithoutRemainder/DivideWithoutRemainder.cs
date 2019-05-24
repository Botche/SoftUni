using System;

namespace divideWithoutRemainder
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            int counter1 = 0, counter2 = 0, counter3 = 0;
            for(var i=0;i<n;i++)
            {
                int a = int.Parse(Console.ReadLine());
                if(a%2==0)
                {
                    counter1++;
                }
                if (a % 3 == 0)
                {
                    counter2++;
                }
                if (a % 4 == 0)
                {
                    counter3++;
                }
            }
            double sum = counter1 / n;
            if (counter1 == 0)
                Console.WriteLine("0.00%");
            else
                Console.WriteLine($"{sum * 100:f2}%");
            sum = counter2 / n;
            if (counter2 == 0)
                Console.WriteLine("0.00%");
            else
                Console.WriteLine($"{sum * 100:f2}%");
            sum = counter3 / n;
            if (counter3 == 0)
                Console.WriteLine("0.00%");
            else
                Console.WriteLine($"{sum * 100:f2}%");
        }
    }
}
