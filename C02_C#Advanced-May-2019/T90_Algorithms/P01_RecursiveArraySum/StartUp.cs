using System;
using System.Linq;

namespace _01._RecursiveArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int sum = RecursiveArraySum(arr, 0);

            Console.WriteLine(sum);
        }

        private static int RecursiveArraySum(int[] arr, int index)
        {
            if (index == arr.Length)
            {
                return 0;
            }

            int result = arr[index] + RecursiveArraySum(arr, ++index);

            return result;
        }
    }
}
