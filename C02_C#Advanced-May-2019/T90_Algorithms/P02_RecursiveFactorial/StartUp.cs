﻿using System;

namespace _02._RecursiveFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int factorial = Factorial(n);

            Console.WriteLine(factorial);
        }

        private static int Factorial(int n)
        {
            if (n==0)
            {
                return 1;
            }

            int result = n * Factorial(n - 1);

            return result;
        }
    }
}
