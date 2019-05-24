using System;
using System.Numerics;

namespace MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger number = BigInteger.Parse(Console.ReadLine());
            int multyplier = int.Parse(Console.ReadLine());

            Console.WriteLine(number*multyplier);
        }
    }
}
