using System;

namespace lowerOrUpper
{
    class Program
    {
        static void Main(string[] args)
        {
            char c = char.Parse(Console.ReadLine());
            if(c>='A'&& c<='Z')
                Console.WriteLine("upper-case");
            else
                Console.WriteLine("lower-case");
        }
    }
}
