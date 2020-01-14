using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int endOfRange = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> nums = new List<int>();
            for (int num = 1; num <= endOfRange; num++)
            {
                bool isValid = true;
                foreach (var divider in dividers)
                {
                    if (num%divider!=0)
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    nums.Add(num);
                }
            }

            Console.WriteLine(string.Join(" ",nums));
        }
    }
}
