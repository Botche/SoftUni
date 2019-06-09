using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestsJournal
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> journal = Console.ReadLine()
                .Split(", ")
                .ToList();
            string[] input = Console.ReadLine().Split(" - ");
            while (input[0]!= "Retire!")
            {
                switch(input[0])
                {
                    case "Start":
                        if (!journal.Contains(input[1]))
                            journal.Add(input[1]);
                        break;
                    case "Complete":
                        if (journal.Contains(input[1]))
                            journal.Remove(input[1]);
                        break;
                    case "Side Quest":
                        string[] quests = input[1].Split(":");
                        if (journal.Contains(quests[0]))
                        {
                            int index=journal.IndexOf(quests[0]);
                            if(!journal.Contains(quests[1]))
                                 journal.Insert(index+1, quests[1]);
                        }
                        break;
                    case "Renew":
                        if (journal.Contains(input[1]))
                        {
                            journal.Remove(input[1]);
                            journal.Add(input[1]);
                        }
                        break;
                    default:
                        break;
                }
                input = Console.ReadLine().Split(" - ");
            }
            Console.WriteLine(string.Join(", ",journal));
        }
    }
}
