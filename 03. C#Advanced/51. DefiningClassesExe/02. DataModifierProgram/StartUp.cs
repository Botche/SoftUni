using System;

namespace DataModifierProgram
{
    public class StartUp
    {
        public static void Main()
        {
            DataModifier twoDates = new DataModifier(
                DateTime.Parse(Console.ReadLine()), DateTime.Parse(Console.ReadLine()));

            int differenceInDays = twoDates.DateDifferenceInDays();

            Console.WriteLine(differenceInDays);
        }
    }
}
