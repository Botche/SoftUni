using System;
using System.Collections.Generic;
using System.Linq;

namespace SantasList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> santasList = Console.ReadLine().Split("&").ToList();

            string[] commands = Console.ReadLine().Split();
            while (commands[0]!="Finished!")
            {
                string command = commands[0];
                string firstKid = commands[1];

                switch(command)
                {
                    case "Bad":
                        if (!santasList.Contains(firstKid))
                            santasList.Insert(0, firstKid);
                        break;
                    case "Good":
                        if (santasList.Contains(firstKid))
                            santasList.Remove(firstKid);
                        break;
                    case "Rename":
                        string secondKid = commands[2];
                        if (santasList.Contains(firstKid))
                        {
                            int index = santasList.IndexOf(firstKid);
                            santasList.Remove(firstKid);
                            santasList.Insert(index, secondKid);
                        }
                        break;
                    case "Rearrange":
                        if (santasList.Contains(firstKid))
                        {
                            santasList.Remove(firstKid);
                            santasList.Add(firstKid);
                        }
                        break;
                }

                commands = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(", ",santasList));
        }
    }
}
