using System;

namespace tribonacciSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int fibNum = int.Parse(Console.ReadLine());
            PringFibSequence(fibNum);
        }

        private static void PringFibSequence(int fibNum)
        {
            int[] fibArr = new int[fibNum];
            for (int i = 0; i < fibNum; i++)
            {
                if (i == 0)
                    fibArr[0] = 1;
                else if (i == 1)
                    fibArr[1] = 1;
                else if (i == 2)
                    fibArr[2] = 2;
                else
                    fibArr[i] = fibArr[i - 1] + fibArr[i - 2] + fibArr[i - 3];
            }
            for (int i = 0; i < fibNum; i++)
            {
                Console.Write(fibArr[i] + " ");
            }
        }
    }
}
