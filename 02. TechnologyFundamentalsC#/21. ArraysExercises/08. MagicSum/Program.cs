﻿using System;
using System.Linq;

namespace magicSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sumToPair = int.Parse(Console.ReadLine());
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] + arr[j] == sumToPair)
                        Console.WriteLine(arr[i] + " " + arr[j]);
                }
            }
        }
    }
}
