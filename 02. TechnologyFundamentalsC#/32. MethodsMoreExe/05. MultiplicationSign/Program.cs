using System;

namespace multiplicationSign
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            double num3 = double.Parse(Console.ReadLine());
            PringSingOfMulti(num1, num2, num3);
        }

        private static void PringSingOfMulti(double num1, double num2, double num3)
        {
            bool neg = false;
            if(num1==0 || num2==0|| num3==0)
                Console.WriteLine("zero");
            else
            {
                if (num1 < 0)
                    neg = true;
                if (num2 < 0 && neg == true)
                    neg = false;
                else if (num2 < 0 && neg == false)
                    neg = true;
                if (num3 < 0 && neg == true)
                    neg = false;
                else if (num3 < 0 && neg == false)
                    neg = true;
                if (neg == false)
                    Console.WriteLine("positive");
                else
                    Console.WriteLine("negative");
            }
        }
    }
}
