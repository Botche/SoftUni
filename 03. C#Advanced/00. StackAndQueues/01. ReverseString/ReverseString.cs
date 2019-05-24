using System;
using System.Collections;

namespace _01._ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            Stack stack = new Stack();

            for (int i = 0; i < str.Length; i++)
            {
                stack.Push(str[i]);
            }

            for (int i = 0; i < str.Length; i++)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
