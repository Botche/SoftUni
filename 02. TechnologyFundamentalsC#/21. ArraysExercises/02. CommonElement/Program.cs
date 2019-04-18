using System;
using System.Linq;

namespace commonElement
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fArray = Console.ReadLine().Split(' ').ToArray();
            string[] sArray = Console.ReadLine().Split(' ').ToArray();
            for (int i = 0; i < sArray.Length; i++)
            {
                if (fArray.Contains(sArray[i]))
                    Console.Write(sArray[i] + " ");
            }
        }
    }
}
