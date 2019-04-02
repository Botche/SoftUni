using System;
using System.Linq;

namespace maxSequenceofEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int counter = 1, index = 0, maxIndex = 0, maxCounter = 1;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == arr[i + 1])
                {
                    counter++;
                    index = arr[i];
                }
                else
                {
                    //Console.WriteLine(counter);
                    counter = 1;
                }
                if (maxCounter < counter)
                {
                    maxCounter = counter;
                    maxIndex = index;
                }
            }
            for (int i = 0; i < maxCounter; i++)
            {
                Console.Write(maxIndex + " ");
            }
        }
    }
}
