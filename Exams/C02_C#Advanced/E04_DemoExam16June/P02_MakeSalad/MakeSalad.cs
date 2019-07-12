using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._MakeSalad
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int[] secondInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> calories = new Stack<int>();
            Queue<string> vegetables = new Queue<string>();
            Queue<int> salads = new Queue<int>();
            for (int i = 0; i < input.Length; i++)
            {
                vegetables.Enqueue(input[i]);
            }

            for (int i = 0; i < secondInput.Length; i++)
            {
                calories.Push(secondInput[i]);
            }
            int salad = 0;
            string vegetable = vegetables.Peek();
            int calorie = calories.Peek();

            while (vegetables.Count != 0 && calories.Count != 0)
            {
                int calorieOfVegetable = 0;

                if (vegetable == "tomato")
                {
                    calorieOfVegetable = 80;
                }
                else if (vegetable == "carrot")
                {
                    calorieOfVegetable = 136;
                }
                else if (vegetable == "lettuce")
                {
                    calorieOfVegetable = 109;
                }
                else if (vegetable == "potato")
                {
                    calorieOfVegetable = 215;
                }

                if (calorieOfVegetable < calorie)
                {
                    salad += calorieOfVegetable;
                    calorie -= calorieOfVegetable;
                }
                else
                {
                    salads.Enqueue(calories.Pop());
                    salad = 0;
                    if (calories.Count != 0)
                    {
                        calorie = calories.Peek();
                    }
                }
                vegetables.Dequeue();
                if (vegetables.Count != 0)
                {
                    vegetable = vegetables.Peek();
                }
                if (vegetables.Count==0 && salad!=0)
                {
                    salads.Enqueue(calories.Pop());
                }
            }
            Console.WriteLine(string.Join(" ", salads));
            if (vegetables.Count == 0)
            {
                Console.WriteLine(string.Join(" ", calories));
            }
            else
            {
                Console.WriteLine(string.Join(" ", vegetables));
            }
        }
    }
}
