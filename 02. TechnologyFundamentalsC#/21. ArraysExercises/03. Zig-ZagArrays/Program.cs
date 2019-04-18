using System;
using System.Linq;

namespace zig_zagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int[] fArray = new int[length];
            int[] sArray = new int[length];
            for (int i = 0; i < length; i++)
            {
                int[] coupleNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (i % 2 == 0)
                {
                    fArray[i] = coupleNumbers[0];
                    sArray[i] = coupleNumbers[1];
                }
                else
                {
                    fArray[i] = coupleNumbers[1];
                    sArray[i] = coupleNumbers[0];
                }
            }
            for (int i = 0; i < length; i++)
            {
                Console.Write(fArray[i] + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < length; i++)
            {
                Console.Write(sArray[i] + " ");
            }
            Console.WriteLine();
        }

    }
}
