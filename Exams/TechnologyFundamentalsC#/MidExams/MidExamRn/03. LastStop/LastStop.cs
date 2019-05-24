using System;
using System.Collections.Generic;
using System.Linq;

namespace LastStop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string[] command = Console.ReadLine()
                .Split();
            while (command[0] != "END")
            {
                switch (command[0])
                {
                    case "Change":
                        int paintNum = int.Parse(command[1]);
                        int changeNum = int.Parse(command[2]);
                        if (nums.Contains(paintNum))
                        {

                            int fIndex = nums.IndexOf(paintNum);
                            nums.Insert(fIndex, changeNum);
                            nums.Remove(paintNum);
                        }

                        break;
                    case "Hide":
                        paintNum = int.Parse(command[1]);
                        if (nums.Contains(paintNum))
                        {
                            nums.Remove(paintNum);
                        }
                        break;
                    case "Switch":
                        paintNum = int.Parse(command[1]);
                        changeNum = int.Parse(command[2]);
                        if (nums.Contains(paintNum) && nums.Contains(changeNum))
                        {
                            int fIndex = nums.IndexOf(paintNum);
                            int sIndex = nums.IndexOf(changeNum);
                            nums.Remove(changeNum);
                            nums.Insert(fIndex, changeNum);
                            nums.Remove(paintNum);
                            nums.Insert(sIndex, paintNum);
                        }
                        break;
                    case "Insert":
                        paintNum = int.Parse(command[2]);
                        int place = int.Parse(command[1]);
                        if (place < nums.Count)
                        {
                            nums.Insert(place + 1, paintNum);
                        }
                        break;

                    case "Reverse":
                        nums.Reverse();
                        break;

                }
                command = Console.ReadLine()
                    .Split();

            }
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
