using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToList();
            List<int> result = new List<int>(nums.Count);
            string command = Console.ReadLine();
            bool b = false;
            while (command != "end")
            {
                string[] commands = command
                    .Split();
                switch (commands[0])
                {
                    case "Add":
                        int num = int.Parse(commands[1]);
                        nums.Add(num);
                        break;
                    case "Remove":
                        num = int.Parse(commands[1]);
                        nums.Remove(num);
                        break;
                    case "RemoveAt":
                        int index = int.Parse(commands[1]);
                        nums.RemoveAt(index);
                        break;
                    case "Insert":
                        num = int.Parse(commands[1]);
                        index = int.Parse(commands[2]);
                        nums.Insert(index, num);
                        break;
                    case "Contains":
                        b = true;
                        num = int.Parse(commands[1]);
                        if (nums.Contains(num))
                            Console.Write("Yes");
                        else
                            Console.Write("No such number");
                        break;
                    case "PrintEven":
                        b = true;
                        for (int i = 0; i < nums.Count; i++)
                        {
                            if (nums[i] % 2 == 0)
                                result.Add(nums[i]);
                        }
                        
                        break;
                    case "PrintOdd":
                        b = true;
                        for (int i = 0; i < nums.Count; i++)
                        {
                            if (nums[i] % 2 == 1)
                                result.Add(nums[i]);
                        }
                        
                        break;
                    case "GetSum":
                        b = true;
                        int sum = 0;
                        for (int i = 0; i < nums.Count; i++)
                        {
                            sum += nums[i];
                        }
                        Console.Write(sum);
                        break;
                    case "Filter":
                        b = true;
                        switch (commands[1])
                        {
                             
                            case "<":

                                for (int i = 0; i < nums.Count; i++)
                                {
                                    if (nums[i] < int.Parse(commands[2]))
                                        result.Add(nums[i]);
                                }
                                
                                break;
                            case ">":
                                for (int i = 0; i < nums.Count; i++)
                                {
                                    if (nums[i] > int.Parse(commands[2]))
                                        result.Add(nums[i]);
                                }
                                
                                break;
                            case "<=":
                                for (int i = 0; i < nums.Count; i++)
                                {
                                    if (nums[i] <= int.Parse(commands[2]))
                                        result.Add(nums[i]);
                                }
                               
                                break;
                            case ">=":
                                for (int i = 0; i < nums.Count; i++)
                                {
                                    if (nums[i] >= int.Parse(commands[2]))
                                        result.Add(nums[i]);
                                }
                                break;
                        }
                        break;
                }
                Console.WriteLine(string.Join(" ",result));
                result.Clear();
                command = Console.ReadLine();
            }
            if (b == false)
                Console.WriteLine(string.Join(" ", nums));
        }
    }
}
