using System;

namespace nXnMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthOfMatrix = int.Parse(Console.ReadLine());

            PrintMatrixWithLength(lengthOfMatrix);
        }

        private static void PrintMatrixWithLength(int lengthOfMatrix)
        {
            for (int i = 0; i < lengthOfMatrix; i++)
            {
                for (int j = 0; j < lengthOfMatrix; j++)
                {
                    Console.Write(lengthOfMatrix + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
