using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listManipulationBasics
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
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
