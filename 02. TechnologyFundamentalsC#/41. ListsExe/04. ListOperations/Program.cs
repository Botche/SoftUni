using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOperations
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
            while (command != "End")
            {
                string[] commandForOperate = command.Split().ToArray();
                if (commandForOperate[0] == "Add")
                {
                    nums.Add(int.Parse(commandForOperate[1]));
                }
                else if (commandForOperate[0] == "Insert")
                {
                    if (int.Parse(commandForOperate[2]) >= nums.Count || int.Parse(commandForOperate[2]) < 0)
                        Console.WriteLine("Invalid index");
                    else
                        nums.Insert(int.Parse(commandForOperate[2]), int.Parse(commandForOperate[1]));
                }
                else if (commandForOperate[0] == "Remove")
                {
                    if (int.Parse(commandForOperate[1]) >= nums.Count || int.Parse(commandForOperate[1]) < 0)
                        Console.WriteLine("Invalid index");
                    else
                        nums.RemoveAt(int.Parse(commandForOperate[1]));
                }
                else if(commandForOperate[0] == "Shift")
                {
                    if (commandForOperate[1] == "left")
                    {
                        for (int i = 0; i < int.Parse(commandForOperate[2]); i++)
                        {
                            nums.Add(nums[0]);
                            nums.RemoveAt(0);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < int.Parse(commandForOperate[2]); i++)
                        {
                            nums.Insert(0, nums[nums.Count - 1]);
                            nums.RemoveAt(nums.Count - 1);
                        }
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ",nums));
        }
    }
}
