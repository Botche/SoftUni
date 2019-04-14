 using System;
using System.Collections.Generic;
using System.Linq;

namespace Min3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int length = int.Parse(Console.ReadLine());

            for (int i = 0; i < length; i++)
            {
                int number = int.Parse(Console.ReadLine());
                numbers.Add(number);
            }
            var sortedNumbers = numbers.OrderBy(x => x).ToList();
            if (numbers.Count < 3)
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    Console.WriteLine(sortedNumbers[i]);
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(sortedNumbers[i]);
                }
            }
        }
    }
}
