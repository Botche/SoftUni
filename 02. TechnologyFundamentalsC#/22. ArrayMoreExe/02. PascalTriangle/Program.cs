using System;

namespace pascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int[,] arr = new int[length+1, length+1];
            arr[0, 0] = 1;
            for (int i = 1; i <= length; i++)
            {
                for (int j = 1; j <= length; j++)
                {
                    arr[i, j] = arr[i - 1, j] + arr[i - 1, j - 1];
                }
            }
            for (int i = 1; i <= length; i++)
            {
                for (int j = 1; j <= length; j++)
                {
                    if(arr[i, j]==0)
                        Console.Write("  ");
                    else
                        Console.Write(arr[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
