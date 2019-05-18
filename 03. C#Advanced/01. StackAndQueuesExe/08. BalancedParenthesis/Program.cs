using System;
using System.Collections.Generic;

namespace _08._BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            bool isBalanced = false;

            Stack<char> open = new Stack<char>();
            int count = 0;

            while (input[count]=='{' || input[count] == '(' || input[count] == '[')
            {
                open.Push(input[count]);
                count++;
            }

            if (input.Length % 2 == 0)
            {
                for (int i = count; i < input.Length; i++)
                {
                    char openP = open.Peek();
                    char closeP = input[count];
                    if ((closeP == '}' && openP == '{')
                        || (closeP == ']' && openP == '[')
                        || (closeP == ')' && openP == '('))
                    {
                        isBalanced = true;
                    }
                    else
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }

            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
