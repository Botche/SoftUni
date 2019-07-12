using System;
using System.Collections.Generic;
using System.Linq;

namespace MixedUpLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numsListOne = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> numsListTwo = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> nums = new List<int>();
            List<int> range = new List<int>(2);

            nums = FillNums(nums, numsListOne, numsListTwo);

            int range1 = 0, range2 = 0;
            if (numsListOne.Count < numsListTwo.Count)
            {
                range1 = numsListTwo[0];
                range2 = numsListTwo[1];
            }
            else
            {
                range1 = numsListOne[numsListOne.Count - 1];
                range2 = numsListOne[numsListOne.Count - 2];
            }

            int maxRange, minRange;
            maxRange = Math.Max(range1, range2);
            minRange = Math.Min(range1, range2);

            List<int> newList = new List<int>();
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] < maxRange && nums[i] > minRange)
                {
                    newList.Add(nums[i]);
                }
            }

            newList.Sort();
            Console.WriteLine(string.Join(" ", newList));
        }
        private static List<int> FillNums(List<int> nums, List<int> numsListOne, List<int> numsListTwo)
        {
            for (int i = 0; i < numsListOne.Count; i++)
            {
                nums.Add(numsListTwo[i]);
                nums.Add(numsListOne[numsListTwo.Count - i - 1]);
            }
            return nums;
        }
    }
}
