using System;
using System.Linq;
namespace reverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nonReverseString = Console.ReadLine().Split().ToArray();
            for (int i = nonReverseString.Length - 1; i >= 0; i--)
            {
                Console.Write(nonReverseString[i] + " ");
            }

        }
    }
}
