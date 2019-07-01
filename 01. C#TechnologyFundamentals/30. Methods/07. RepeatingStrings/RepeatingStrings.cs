using System;

namespace repeatingStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int timesToRepeat = int.Parse(Console.ReadLine());

            Console.WriteLine(RepeatString(str, timesToRepeat));
        }

        private static string RepeatString(string str, int timesToRepeat)
        {
            string oldStr = str;
            str = "";
            for (int i = 0; i < timesToRepeat; i++)
            {
                str += oldStr;
            }
            return str;
        }
    }
}
