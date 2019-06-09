using System;

namespace _02._CustomStack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            CustomStack customStack = new CustomStack();
            for (int i = 0; i < 8; i++)
            {
                customStack.Add(i + 1);
            }
            Console.WriteLine(customStack.Pop());

            Console.WriteLine(customStack.Peek());

            customStack.ForEach(Console.WriteLine);
        }
    }
}
