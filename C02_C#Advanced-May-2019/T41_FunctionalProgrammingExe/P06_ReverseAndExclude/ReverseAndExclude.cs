using System;
using System.Linq;

namespace _06._ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int numberToDivide = int.Parse(Console.ReadLine());

            int[] result = nums
                .Where(n => n % numberToDivide != 0)
                .Reverse()
                .ToArray();

            Console.WriteLine(string.Join(" ",result));
        }
    }
}
