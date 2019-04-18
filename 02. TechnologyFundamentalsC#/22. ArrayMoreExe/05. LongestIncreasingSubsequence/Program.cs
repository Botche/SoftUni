using System;
using System.Linq;

namespace longestIncreasingSubsequence
{
    class Program
    {
        static void Main()
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int length = arr.Length;
            int[] len = new int[length];
            int[] prev = new int[length];
            if (length == 1)
                Console.WriteLine(arr[0]);
            else
            {
                for (int i = 0; i < length; i++)
                {
                    len[i] = 1;
                }
                prev[0] = -1;
                for (int i = 1; i < length; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (arr[j] < arr[i] && len[i] < len[j] + 1)
                        {
                            len[i] = len[j] + 1;
                            prev[i] = j;
                        }
                    }
                    if (len[i] == 1)
                        prev[i] = -1;
                }
                int maxLen = 0, index = 0;
                for (int i = 0; i < length; i++)
                {
                    if (maxLen < len[i])
                    {
                        maxLen = len[i];
                        index = i;
                    }
                    else if (maxLen == len[i])
                    {
                        if (index > i)
                        {
                            maxLen = len[i];
                            index = i;
                        }
                    }
                }
                int[] newArr = new int[length];
                int counter = 0;
                for (int i = index; i >= 0; i--)
                {
                    newArr[counter] = arr[i];
                    i = prev[i] + 1;
                    counter++;
                }
                for (int i = counter - 1; i >= 0; i--)
                {
                    Console.Write(newArr[i] + " ");
                }
            }
        }
    }
}
