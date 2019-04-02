using System;
using System.Linq;

namespace arrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] number = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int length = int.Parse(Console.ReadLine());
            int[] newArray = new int[number.Length];
            for (int i = 0; i < length; i++)
            {
                newArray[number.Length-1] = number[0];
                for (int j = 0; j < number.Length-1; j++)
                {
                    newArray[j] = number[j + 1];
                }
                number = newArray;
                newArray =new int[number.Length];
            }
            for (int i = 0; i < newArray.Length; i++)
            {
                Console.Write(number[i] + " ");
            }
        }
    }
}
