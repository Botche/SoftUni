﻿using System;

namespace triplesofLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for(int i=0;i<n;i++)
            {
                for(int j=0;j<n;j++)
                {
                    for(int k=0;k<n;k++)
                    {
                        Console.WriteLine($"{(char)(i+97)}{(char)(j + 97)}{(char)(k + 97)}");
                    }
                }
            }
        }
    }
}
