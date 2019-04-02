using System;
using System.Collections.Generic;

namespace TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            List<int> nums = new List<int>();
            List<char> NaN = new List<char>();
            List<int> takeList = new List<int>();
            List<int> dropList = new List<int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]))
                {
                    nums.Add(str[i] - 48);
                }
                else
                    NaN.Add(str[i]);
            }
            for (int i = 0; i < nums.Count; i++)
            {

                if (i % 2 == 0)
                {
                    takeList.Add(nums[i]);
                }
                else
                    dropList.Add(nums[i]);
            }
            string newStr = ""; int j = 0;
            for (int i = 0; i < takeList.Count; i++)
            {
                //Console.WriteLine(takeList[i]);
                for (j = 0; j < takeList[i]; j++)
                {
                    if (j >= NaN.Count)
                    {
                        break;
                    }
                    newStr += NaN[j];
                }
                //Console.WriteLine(string.Join("", NaN));
                if(j + dropList[i]>=NaN.Count)
                {
                    break;
                }
                else
                    NaN.RemoveRange(0, j + dropList[i]);
                //Console.WriteLine(string.Join("", NaN));
            }
            Console.WriteLine(newStr);
        }
    }
}
