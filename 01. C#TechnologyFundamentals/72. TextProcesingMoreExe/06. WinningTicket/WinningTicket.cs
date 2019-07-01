using System;
using System.Text.RegularExpressions;

namespace _04.WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            string[] tickets = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //Looping
            foreach (var ticket in tickets)
            {
                //Checking is valid
                if (ticket.Length == 20)
                {
                    Regex pattern = new Regex(@"[@]{6,10}|[#]{6,10}|[$]{6,10}|[\^]{6,10}");
                    string firstHalf = ticket.Substring(0, 10);
                    string secondHalf = ticket.Substring(10);
                    //Find Matches
                    Match firstMatch = pattern.Match(firstHalf);
                    Match secondMatch = pattern.Match(secondHalf);
                    //Taking length && symbols
                    int firstLength = firstMatch.Length;
                    int secondLength = secondMatch.Length;
                    char firstSymbol = ' ';
                    char secondSymbol = ' ';
                    //Best length
                    int length = Math.Min(firstLength, secondLength);
                    //Output
                    char quot = '"';
                    if (length >= 6)
                    {
                        firstSymbol = firstMatch.ToString()[0];
                        secondSymbol = secondMatch.ToString()[0];

                        if (firstSymbol == secondSymbol && length < 10)
                            Console.WriteLine($"ticket {quot}{ticket}{quot} - {length}{firstSymbol}");
                        else if (firstSymbol == secondSymbol && length == 10)
                            Console.WriteLine($"ticket {quot}{ticket}{quot} - {length}{firstSymbol} Jackpot!");
                        else
                            Console.WriteLine($"ticket {quot}{ticket}{quot} - no match");
                    }
                    else
                        Console.WriteLine($"ticket {quot}{ticket}{quot} - no match");
                }
                else
                    Console.WriteLine("invalid ticket");
            }

        }
    }
}
