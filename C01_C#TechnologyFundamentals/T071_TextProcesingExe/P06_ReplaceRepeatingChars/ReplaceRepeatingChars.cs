using System;
using System.Text;

namespace ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            sb.Append( str[0]);
            char lastChar = str[0];

            for (int i = 1; i < str.Length; i++)
            {
                char ch = str[i];
                if(lastChar!=ch)
                {
                    sb.Append(ch);
                    lastChar = ch;
                }
            }
            Console.WriteLine(sb);
        }
    }
}
