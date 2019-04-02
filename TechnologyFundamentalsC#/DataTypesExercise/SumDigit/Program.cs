using System;

class Program
{
    static void Main()
    {
        string data = "there is a cat";
        // Split string on spaces (this will separate all the words).
        string[] words = data.Split(' ');
        foreach (string cat in words)
        {
            Console.WriteLine("WORD: " + cat);
        }
    }
}