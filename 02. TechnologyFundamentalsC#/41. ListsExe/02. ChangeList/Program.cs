using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] commandForChange = command.Split().ToArray();
                if(commandForChange[0]=="Delete")
                {
                    int elementForRemoving = int.Parse(commandForChange[1]);
                    nums.Remove(elementForRemoving);
                }
                else
                {
                    int elementToInsert = int.Parse(commandForChange[1]);
                    int indexToInsert= int.Parse(commandForChange[2]);
                    nums.Insert(indexToInsert,elementToInsert);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ",nums));
        }
    }
}
