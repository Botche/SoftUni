using System;

namespace charactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char lowRangeOfLoop = char.Parse(Console.ReadLine());
            char highRangeOfLoop = char.Parse(Console.ReadLine());

            CharsInRange(lowRangeOfLoop, highRangeOfLoop);
        }

        private static void CharsInRange(char lowRangeOfLoop, char highRangeOfLoop)
        {
            if (lowRangeOfLoop<highRangeOfLoop)
            {
                for (int i = lowRangeOfLoop+1; i < highRangeOfLoop; i++)
                {
                    Console.Write((char)i+" ");
                }
            }
            else
            {
                for (int i = highRangeOfLoop+1; i < lowRangeOfLoop; i++)
                {
                    Console.Write((char)i + " ");
                }
            }
        }
    }
}
