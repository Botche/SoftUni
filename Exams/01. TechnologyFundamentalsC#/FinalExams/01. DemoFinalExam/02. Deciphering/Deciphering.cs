using System;
using System.Linq;
using System.Text;

namespace Deciphering
{
    class Program
    {
        static void Main(string[] args)
        {
            string encryptedStr = Console.ReadLine();

            string[] letters = Console.ReadLine().Split(" ");

            char[] chs = { '{', '}', '|', '#', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            bool isValid = true;
            foreach (var symbol in encryptedStr)
            {
                if (!chs.Contains(symbol))
                { 
                    Console.WriteLine("This is not the book you are looking for.");
                    isValid = false;
                    break;
                }
            }
            if (isValid == true)
            {
                StringBuilder reducedEncryptedStr = new StringBuilder();
                foreach (var letter in encryptedStr)
                {
                    reducedEncryptedStr.Append((char)(letter - 3));
                }

                reducedEncryptedStr.Replace(letters[0], letters[1]);
                Console.WriteLine(reducedEncryptedStr);
            }
        }
    }
}
