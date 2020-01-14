using System;

namespace P03_Fixing
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] weeekdays = new string[5];
            weeekdays[0] = "Sunday";
            weeekdays[1] = "Monday";
            weeekdays[2] = "Tuesday";
            weeekdays[3] = "Wednesday";
            weeekdays[4] = "Thursday";

            for (int i = 0; i < 6; i++)
            {
                try
                {
                    Console.WriteLine(weeekdays[i]);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Week is short");
                }
            }
        }
    }
}
