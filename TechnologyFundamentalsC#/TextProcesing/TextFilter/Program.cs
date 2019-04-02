using System;

namespace TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();

            for (int i = 0; i < bannedWords.Length; i++)
            {
                while (text.Contains(bannedWords[i]))
                {
                    string strToReplace = new string('*', bannedWords[i].Length);
                    text=text.Replace(bannedWords[i], strToReplace);
                }
            }
            Console.WriteLine(text);
        }
    }
}
