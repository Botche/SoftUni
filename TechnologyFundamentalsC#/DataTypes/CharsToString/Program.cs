using System;

namespace charsToString
{
    class Program
    {
        static void Main(string[] args)
        {
            char char1 = char.Parse(Console.ReadLine());
            char char2 = char.Parse(Console.ReadLine());
            char char3 = char.Parse(Console.ReadLine());
            string strOfChars = "";
            strOfChars += char1; strOfChars += char2; strOfChars += char3;
            Console.WriteLine(strOfChars);
        }
    }
}
