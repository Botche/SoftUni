using System;
using System.Collections.Generic;
using System.Linq;

namespace AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> nums = Console.ReadLine()
                .Split("|")
                .ToList();
            for (int i = nums.Count - 1; i >= 0; i--)
            {
                List<int> listOfNums = nums[i]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
                foreach (var item in listOfNums)
                {
                    Console.Write(item+ " " );
                }
            }
        }
    }
}
