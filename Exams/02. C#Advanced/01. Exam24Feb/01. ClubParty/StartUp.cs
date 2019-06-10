using System;
using System.Collections.Generic;

namespace _01._ClubParty
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int maxCapacity = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Stack<string> digitsOrLetter = new Stack<string>();

            for (int i = 0; i < input.Length; i++)
            {
                digitsOrLetter.Push(input[i]);
            }

            Queue<string> letters = new Queue<string>();
            Queue<int> digitsAttachedToLetter = new Queue<int>();
            int currentSum = 0;

            while (digitsOrLetter.Count!=0)
            {
                string currentStackElement = digitsOrLetter.Peek();

                if (char.IsLetter(currentStackElement[0]))
                {
                    letters.Enqueue(currentStackElement);
                    digitsOrLetter.Pop();
                    continue;
                }
                else
                {
                    if (letters.Count==0)
                    {
                        digitsOrLetter.Pop();
                        continue;
                    }

                    string letter = letters.Peek();
                    int digit = int.Parse(currentStackElement);

                    if (currentSum + digit > maxCapacity)
                    {
                        Console.WriteLine($"{letter} -> {string.Join(", ", digitsAttachedToLetter)}");

                        letters.Dequeue();
                        currentSum = 0;
                        digitsAttachedToLetter = new Queue<int>();
                    }
                    else
                    {
                        digitsAttachedToLetter.Enqueue(digit);
                        currentSum += digit;
                        digitsOrLetter.Pop();
                    }
                }
            }
        }
    }
}
