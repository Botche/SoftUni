using System;

namespace CharacterMultiplyer
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split();
            string str1 = strings[0];
            string str2 = strings[1];
            int sumOfChars = 0;

            if (str1.Length <= str2.Length)
            {
                for (int i = 0; i < str1.Length; i++)
                {
                    sumOfChars += str1[i] * str2[i];
                }
                for (int i = str1.Length; i < str2.Length; i++)
                {
                    sumOfChars += str2[i];
                }
            }
            else
            {
                for (int i = 0; i < str2.Length; i++)
                {
                    sumOfChars += str1[i] * str2[i];
                }
                for (int i = str2.Length; i < str1.Length; i++)
                {
                    sumOfChars += str1[i];
                }
            }
            Console.WriteLine(sumOfChars);
        }
    }
}
