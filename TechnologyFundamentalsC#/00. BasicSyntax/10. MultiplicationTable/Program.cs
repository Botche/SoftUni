﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for(int i=1;i<=10;i++)
            {
                Console.WriteLine($"{num} X {i} = {num*i}");
            }
        }
    }
}