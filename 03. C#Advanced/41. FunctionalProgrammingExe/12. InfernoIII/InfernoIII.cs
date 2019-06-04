using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._InfernoIII
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> originalSet = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string[] input = new string[3];
            List<string> actions = new List<string>();
            while ((input = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries))[0]
                != "Forge")
            {
                string command = input[0];
                string action = input[1] + ";" + input[2];

                AddOrRemoveActions(command, actions, action);
            }
            bool[] isForged = new bool[originalSet.Count];

            UseActionsOnNums(originalSet, actions, isForged);

            PrintAliveGems(originalSet, isForged);
        }

        private static void PrintAliveGems(List<int> originalSet, bool[] isForged)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < originalSet.Count; i++)
            {
                if (isForged[i] == false)
                {
                    result.Add(originalSet[i]);
                }
            }
            Console.WriteLine(string.Join(" ",result));
        }

        private static void UseActionsOnNums(List<int> nums, List<string> actions, bool[] isForged)
        {
            foreach (var action in actions)
            {
                string filter = action.Split(";", StringSplitOptions.RemoveEmptyEntries)[0];
                int parameter = int.Parse(action.Split(";", StringSplitOptions.RemoveEmptyEntries)[1]);

                switch (filter)
                {
                    case "Sum Left":
                        ExcludeLeftSumNumbers(nums, parameter, isForged);
                        break;
                    case "Sum Right":
                        ExcludeRigthSumNumbers(nums, parameter, isForged);
                        break;
                    case "Sum Left Right":
                        ExcludeBothSumNumbers(nums, parameter, isForged);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void ExcludeBothSumNumbers(List<int> nums, int parameter, bool[] isForged)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                int sumator = 0;
                if (i != 0 && i != nums.Count-1)
                {
                    sumator = nums[i - 1] + nums[i + 1];
                }
                else if (i == 0)
                {
                    sumator = nums[i + 1];
                }
                else if (i == nums.Count - 1)
                {
                    sumator = nums[i - 1];
                }

                if (nums[i] + sumator == parameter)
                {
                    isForged[i] = true;
                }
            }
        }

        private static void ExcludeRigthSumNumbers(List<int> nums, int parameter, bool[] isForged)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                int sumator = 0;
                if (i != nums.Count-1)
                {
                    sumator = nums[i + 1];
                }

                if (nums[i] + sumator == parameter)
                {
                    isForged[i] = true;
                }
            }
        }

        private static void ExcludeLeftSumNumbers(List<int> nums, int parameter, bool[] isForged)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                int sumator = 0;
                if (i != 0)
                {
                    sumator = nums[i - 1];
                }

                if (nums[i] + sumator == parameter)
                {
                    isForged[i] = true;
                }
            }
        }

        private static void AddOrRemoveActions(string command, List<string> actions, string action)
        {
            if (command == "Exclude")
            {
                actions.Add(action);
            }
            else
            {
                if (actions.Contains(action))
                {
                    actions.Remove(action);
                }
            }
        }
    }
}
