using System;
using System.Linq;

namespace _08._CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] evenNumbers = nums
                .Where(n => n % 2 == 0)
                .OrderBy(n => n)
                .ToArray();
            int[] oddNumbers = nums
                .Where(n => n % 2 != 0)
                .OrderBy(n => n)
                .ToArray();

            Console.WriteLine(string.Join(" ", evenNumbers) + " " + string.Join(" ", oddNumbers));
        }
    }
}
