using System;

namespace oldBooks
{
    class Program
    {
        static void Main()
        {
            string favBook = Console.ReadLine();
            int br = int.Parse(Console.ReadLine());
            int counter=0;
            while(true)
            {
                string book = Console.ReadLine();
                if(book==favBook)
                {
                    Console.WriteLine($"You checked {counter} books and found it.");
                    break;
                }

                counter++;
                if(counter==br)
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {counter} books.");
                    break;
                }
            }
        }
    }
}
