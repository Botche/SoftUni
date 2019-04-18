using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> list2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> result = new List<int>(100);
            int counter = 0;
            if (list1.Count == list2.Count)
            {
                for (int i = 0; i < list1.Count * 2; i++)
                {
                    if (i == 0)
                    {
                        result.Add(list1[counter]);
                    }
                    else if (i % 2 == 1)
                    {
                        result.Add(list2[counter]);
                        counter++;
                    }
                    else
                    {
                        result.Add(list1[counter]);
                    }
                }
            }
            else if (list1.Count < list2.Count)
            {
                for (int i = 0; i < list1.Count * 2; i++)
                {
                    if (i == 0)
                    {
                        result.Add(list1[counter]);
                    }
                    else if (i % 2 == 1)
                    {
                        result.Add(list2[counter]);
                        counter++;
                    }
                    else
                    {
                        result.Add(list1[counter]);
                    }
                }
                for (int i = list1.Count; i < list2.Count; i++)
                {
                    result.Add(list2[counter]);
                    counter++;
                }
            }
            else 
            {
                for (int i = 0; i < list2.Count * 2; i++)
                {
                    if (i == 0)
                    {
                        result.Add( list1[counter]);
                    }
                    else if (i % 2 == 1)
                    {
                        result.Add(list2[counter]);
                        counter++;
                    }
                    else
                    {
                        result.Add(list1[counter]);
                    }
                }
                for (int i = list2.Count; i < list1.Count; i++)
                {
                    result.Add(list1[counter]);
                    counter++;
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
