using System;

namespace factorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            //Console.WriteLine(num1 + "" + num2);
            long fac1 = ReturnFactorialSumOfFirst(num1);
            long fac2 = ReturnFactorialSumOfSecond(num2);
            //Console.WriteLine(num1 + "" + num2);
            PrintFactorialSum(fac1, fac2);
        }

        private static long ReturnFactorialSumOfFirst(int num1)
        {
            long fac = 1;
            for (int i = 2; i <= num1; i++)
            {
                fac *= i;
            }
            return fac;
        }

        private static long ReturnFactorialSumOfSecond(int num2)
        {
            long fac = 1;
            for (int i = 2; i <= num2; i++)
            {
                fac *= i;
            }
            return fac;
        }

        private static void PrintFactorialSum(double num1, double num2)
        {
            Console.WriteLine($"{num1 / num2:f2}");
        }
    }
}
