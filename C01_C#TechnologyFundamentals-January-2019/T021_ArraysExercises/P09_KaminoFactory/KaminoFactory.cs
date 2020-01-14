using System;
using System.Linq;

namespace kaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int counter = 1, sum = 0, maxCounter = 1, index = 0, bestIndex = 0, counterOnes = 0, maxSum = 0, position = 0, bestPosition = int.MaxValue;
            int[] bestArr = new int[length];
            while (true)
            {
                index++; sum = 0;
                string command = Console.ReadLine();
                if (command == "Clone them!")
                    break;
                int[] arr = command.Split('!', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                sum += arr[0];
                for (int i = 1; i < length; i++)
                {
                    if (arr[i - 1] == arr[i] && arr[i - 1] == 1)
                    {
                        counter++;
                        position = i;
                    }
                    sum += arr[i];
                }
                position -= counter - 2;

                if (maxCounter <= counter)
                {
                    if (maxCounter == counter)
                    {
                        if (bestPosition >= position)
                        {
                            if (bestPosition == position)
                            {
                                if (maxSum < sum)
                                {
                                    maxSum = sum;
                                    maxCounter = counter;
                                    bestArr = arr;
                                    bestIndex = index;
                                    bestPosition = position;
                                }
                            }
                            else
                            {
                                maxSum = sum;
                                maxCounter = counter;
                                bestArr = arr;
                                bestIndex = index;
                                bestPosition = position;
                            }
                        }
                    }
                    else
                    {
                        maxSum = sum;
                        maxCounter = counter;
                        bestArr = arr;
                        bestIndex = index;
                        bestPosition = position;
                    }
                }
                counter = 1;
            }
            Console.WriteLine($"Best DNA sample {bestIndex} with sum: {maxSum}.");
            for (int i = 0; i < length; i++)
            {
                Console.Write(bestArr[i] + " ");
            }
        }
    }
}
