using System;
using System.Linq;

namespace roundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] roundingNumbers = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            for (int i = 0; i < roundingNumbers.Length; i++)
            {
                Console.WriteLine($"{roundingNumbers[i]} => {(int)Math.Round(roundingNumbers[i],MidpointRounding.AwayFromZero)}");
            }

        }
    }
}
