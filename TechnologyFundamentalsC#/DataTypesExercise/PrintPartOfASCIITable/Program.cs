using System;

namespace printPartOfASCIITable
{
    class Program
    {
        static void Main(string[] args)
        {
            int minRange = int.Parse(Console.ReadLine());
            int maxRange = int.Parse(Console.ReadLine());
            for (int i = minRange; i <= maxRange; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
