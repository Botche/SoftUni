using System;
using System.Linq;

namespace sumEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sum = 0;
            for (int i = 0; i < intArray.Length; i++)
            {
                if (intArray[i] % 2 == 0)
                    sum += intArray[i];
            }
            Console.WriteLine(sum);
        }
    }
}
