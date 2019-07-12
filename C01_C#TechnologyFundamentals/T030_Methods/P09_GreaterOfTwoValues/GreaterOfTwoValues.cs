using System;

namespace greaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfValues = Console.ReadLine();

            if (typeOfValues == "int")
            {
                int valueOne = int.Parse(Console.ReadLine());
                int valueTwo = int.Parse(Console.ReadLine());
                Console.WriteLine(ReturnsGreterValueOfInt(valueOne, valueTwo));
            }
            else if (typeOfValues == "string")
            {
                string valueOne = Console.ReadLine();
                string valueTwo = Console.ReadLine();
                Console.WriteLine(ReturnsGreterValueOfStrings(valueOne, valueTwo));
            }
            else if (typeOfValues == "char")
            {
                char valueOne = char.Parse(Console.ReadLine());
                char valueTwo = char.Parse(Console.ReadLine());
                Console.WriteLine(ReturnsGreterValueOfChars(valueOne, valueTwo));
            }
        }

        private static char ReturnsGreterValueOfChars(char valueOne, char valueTwo)
        {
            if (valueOne >= valueTwo)
                return valueOne;
            else
                return valueTwo;
        }

        private static string ReturnsGreterValueOfStrings(string valueOne, string valueTwo)
        {

            int length = valueOne.CompareTo(valueTwo);
            if (length >0)
                return valueOne;
            else
                return valueTwo;
        }

        private static int ReturnsGreterValueOfInt(int valueOne, int valueTwo)
        {
            return Math.Max(valueOne, valueTwo);
        }
    }
}

