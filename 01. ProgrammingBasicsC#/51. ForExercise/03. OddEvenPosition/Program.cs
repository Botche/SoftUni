using System;

namespace oddEvenPosition
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            double oddSum = 0, oddMin = double.MaxValue, oddMax = double.MinValue;
            double evenSum = 0, evenMin = double.MaxValue, evenMax = double.MinValue;

            for(var i=1;i<=n;i++)
            {
                double a = double.Parse(Console.ReadLine());
                if(i%2==0)
                {
                    evenSum += a;
                    if (evenMax < a)
                        evenMax = a;
                    if (evenMin > a)
                        evenMin = a;
                }
                else
                {
                    oddSum += a;
                    if (oddMax < a)
                        oddMax = a;
                    if (oddMin > a)
                        oddMin = a;
                }
            }
            Console.WriteLine($"OddSum={oddSum},");
            if(oddMin==double.MaxValue)
                Console.WriteLine("OddMin=No,");
            else
                Console.WriteLine($"OddMin={oddMin},");
            if (oddMax == double.MinValue)
                Console.WriteLine("OddMax=No,");
            else
                Console.WriteLine($"OddMax={oddMax},");
            Console.WriteLine($"EvenSum={evenSum},");
            if (evenMin == double.MaxValue)
                Console.WriteLine("EvenMin=No,");
            else
                Console.WriteLine($"EvenMin={evenMin},");
            if (evenMax == double.MinValue)
                Console.WriteLine("EvenMax=No");
            else
                Console.WriteLine($"EvenMax={evenMax}");
        }
    }
}
