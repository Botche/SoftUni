﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sumOfOddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int num = 1, sum = 0;
            for(int i=0;i<n;i++)
            {
                Console.WriteLine(num);
                sum += num;
                num += 2;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}