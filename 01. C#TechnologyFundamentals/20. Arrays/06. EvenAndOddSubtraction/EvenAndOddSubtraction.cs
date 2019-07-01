using System;
using System.Linq;

namespace evenandOddSubtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                    sum += arr[i];
                else
                    sum -= arr[i];
            }
            Console.WriteLine(sum);
        }
    }
}
