using System;

namespace bonusScore
{
    class Program
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            double sum=0.0;
            if(a<=100)
            {
                sum += 5;
            }
            else
            {
                if (a > 100 && a <= 1000)
                {
                    sum = sum + a * 0.2;
                }
                else sum = sum + a * 0.1;
            }
            if (a % 2 == 0)
                sum++;
            else
            {
                if (a % 5 == 0)
                    sum += 2;
            }
            Console.WriteLine(sum);
            Console.WriteLine(a+sum);
        }
    }
}
