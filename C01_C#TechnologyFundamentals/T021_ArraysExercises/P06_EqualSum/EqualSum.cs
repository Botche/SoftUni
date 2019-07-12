using System;
using System.Linq;

namespace equalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int lSum = 0, rSum = 0,index=-1;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int k = i+1; k < arr.Length; k++)
                {
                    rSum += arr[k];
                }
                for (int j = i-1; j >= 0; j--)
                {
                    lSum += arr[j];
                }
                if (lSum == rSum)
                    index = i;
                rSum = lSum = 0;
            }
            if (index == -1)
                Console.WriteLine("no");
            else
                Console.WriteLine(index);
        }
    }
}
