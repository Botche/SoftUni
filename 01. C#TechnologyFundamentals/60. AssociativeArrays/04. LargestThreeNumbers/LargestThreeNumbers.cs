using System;
using System.Linq;

namespace LargestThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var sorted = nums.OrderByDescending(x => x).Take(3);
            Console.WriteLine(string.Join(" ",sorted)); 
        }
    }
}
