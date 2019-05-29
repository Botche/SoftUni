using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> uniqueElements = new HashSet<string>();

            int length = int.Parse(Console.ReadLine());
            for (int i = 0; i < length; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split();
                for (int j = 0; j < elements.Length; j++)
                {
                    uniqueElements.Add(elements[j]);
                }
            }
            var sortedElemtents = uniqueElements.OrderBy(x => x);
            Console.WriteLine(string.Join(" ",sortedElemtents));
        }
    }
}
