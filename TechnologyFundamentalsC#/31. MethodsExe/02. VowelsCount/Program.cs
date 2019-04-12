using System;

namespace vowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            Console.WriteLine(   CountVowelsInString(str));
        }

        private static int CountVowelsInString(string str)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'a' || str[i] == 'i'
                    || str[i] == 'u' || str[i] == 'o'
                    || str[i] == 'y' || str[i] == 'e'
                    || str[i] == 'Y' || str[i] == 'E'
                    || str[i] == 'U' || str[i] == 'I'
                    || str[i] == 'O' || str[i] == 'A')
                    count++;
            }
            return count;
        }
    }
}
