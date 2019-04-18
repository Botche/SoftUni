using System;

namespace Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string chars = Console.ReadLine();
            string str = Console.ReadLine();

            while (str.Contains(chars))
            {
                int index=str.IndexOf(chars);
                str=str.Remove(index, chars.Length);
            }
            Console.WriteLine(str);
        }
    }
}
