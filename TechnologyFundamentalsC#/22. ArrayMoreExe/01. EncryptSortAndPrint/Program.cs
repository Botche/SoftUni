using System;

namespace encryptSortAndPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int sum = 0;
            int[] newArr = new int[length];
            for (int i = 0; i < length; i++)
            {
                string str = Console.ReadLine();
                for(int j=0;j<str.Length;j++)
                {
                    if ("aeiouAEIOU".Contains(str[j]))
                    {
                        sum += str[j] * str.Length;
                    }
                    else
                        sum += str[j] / str.Length;
                    //Console.WriteLine(str[j]);
                }
                newArr[i] = sum;
                sum = 0;
            }
            Array.Sort(newArr);
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(newArr[i]);
            }
        }
    }
}
