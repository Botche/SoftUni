using System;

namespace CookingFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("#");
            string[] bestInput = input;
            int sum = 0, bestSum = int.MinValue;
            while(input[0]!="Bake It!")
            {
                for (int i = 0; i < input.Length; i++)
                {
                    sum += int.Parse(input[i]);
                }
                
                if(bestSum<sum)
                {
                    bestInput = input;
                    bestSum = sum;
                }
                else if(bestSum==sum)
                {
                    int Quality = sum / input.Length;
                    int bQuality = bestSum / bestInput.Length;
                    if(bQuality<Quality)
                    {
                        bestInput = input;
                        bestSum = sum;
                    }
                    else if(Quality==bQuality)
                    {
                        if(input.Length<bestInput.Length)
                        {
                            bestInput = input;
                            bestSum = sum;
                        }
                    }
                }

                sum = 0;
                input = Console.ReadLine().Split("#");
            }
            Console.WriteLine($"Best Batch quality: {bestSum}");
            Console.WriteLine(string.Join(" ",bestInput));
        }
    }
}
