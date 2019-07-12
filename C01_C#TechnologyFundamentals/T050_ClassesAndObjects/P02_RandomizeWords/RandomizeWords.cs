using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split()
                .ToList();
            Random rnd = new Random();
            for (int  i = 0;  i < list.Count;  i++)
            {
                int index = rnd.Next(0, list.Count);
                string listItem = list[i];
                list.RemoveAt(i);
                list.Insert(index, listItem);
            }
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
