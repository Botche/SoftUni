//using System;
//using System.Linq;

//namespace foldAndSum
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
//            int length = arr.Length / 4;
//            int[] newArr = new int[arr.Length * 2];
//            int j = 0;
//            for (int i = length; i < length * 2; i++)
//            {
//                newArr[j] = arr[i] + arr[length * 2 - i - 1];
//                j++;
//            }
//            for (int i = length * 2; i < length * 3; i++)
//            {
//                newArr[j] = arr[i] + arr[length * 6 - 1 - i];
//                j++;
//            }
//            for (int i = 0; i < length * 2; i++)
//            {
//                Console.Write(newArr[i] + " ");
//            }
//        }
//    }
//}
using System;
using System.Linq;

namespace longestIncreasingSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int length = arr.Length;
            int[] len = new int[length];
            int[] prev = new int[length];
            for (int p = 0; p < length; p++)
            {
                if (p == 0)
                {
                    len[p] = 1;
                    prev[p] = -1;
                }
                else
                {
                    int minIndex = Array.IndexOf(arr, arr.Min());
                    for (int left = p - 1; left >= 0; left--)
                    {
                        if (arr[left] < arr[p])
                        {
                            if (arr[minIndex] < arr[left])
                            {
                                prev[p] = left;
                                len[p] = 1 + len[left];
                                minIndex = left;
                            }
                            else
                            {
                                prev[p] = minIndex;
                                len[p] = 1 + len[minIndex];
                            }
                        }
                    }
                    if (len[p] == 0)
                        len[p] = 1;
                    //if (prev[p] == 0)
                    //    prev[p] = -1;
                }
            }
            int max = int.MinValue;
            int index = 0;
            for (int p = length - 1; p >= 0; p--)
            {
                if (max < len[p])
                {
                    max = len[p];
                    index = p;
                }
                else if (max == len[p])
                {
                    if (arr[index] <= arr[p])
                    {
                        max = len[p];
                        index = p;
                    }
                }
            }
            int[] newArr = new int[length];
            int counter = 0, oldP = 0;
            for (int p = index; p >= 0; p--)
            {
                if (p == 0 && arr[p] < newArr[counter])
                    continue;
                newArr[counter] = arr[p];
                oldP = p;
                oldP = prev[p] + 1;
                for (int i = p - 1; i >= 0; i--)
                {
                    if (len[p] == len[i])
                    {
                        if (arr[i] > arr[p] && arr[i] < newArr[counter - 1])
                        {
                            newArr[counter] = arr[i];
                            oldP = prev[i] + 1;
                        }
                    }
                }
                p = oldP;
                counter++;
            }
            for (int i = counter - 1; i >= 0; i--)
            {
                Console.Write(newArr[i] + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < length; i++)
            {
                Console.Write(len[i] + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < length; i++)
            {
                Console.Write(prev[i] + " ");
            }
        }
    }
}