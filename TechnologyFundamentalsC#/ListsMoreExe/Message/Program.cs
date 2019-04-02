using System;
using System.Collections.Generic;
using System.Linq;

namespace Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string str = Console.ReadLine();
            string newStr = "";
            int[] sum = new int[nums.Count];
            GetSumOfElems(nums, sum);
            GetElementFromString(sum, str, newStr);
        }

        private static void GetElementFromString(int[] sum, string str, string newStr)
        {

            for (int i = 0; i < sum.Length; i++)
            {
                int multi = sum[i] / str.Count();
                sum[i] = sum[i] - str.Count() * multi;
                newStr += str[sum[i]];
                //Console.WriteLine(sum[i]);
                str=str.Remove(sum[i],1);
                //Console.WriteLine(str);
            }
            Console.WriteLine(newStr);
        }

        private static void GetSumOfElems(List<int> nums, int[] sum)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                while (nums[i] > 0)
                {
                    int num = nums[i] % 10;
                    sum[i] += num;
                    nums[i] /= 10;
                }
            }
        }
    }
}

