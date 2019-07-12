using System;
using System.Collections.Generic;
using System.Linq;

namespace Trojan_Invasion
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine()); // number of waves Trojans

            int[] spartanDefense = Console.ReadLine() // spartans
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> spartans = new Stack<int>(spartanDefense.Reverse()); // ????
            Stack<int> trojans = new Stack<int>();

            for (int i = 1; i <= waves; i++) // Trojans power for each warrior
            {

                int[] trojanAttack = Console.ReadLine() // Trojans coming
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();

                foreach (var item in trojanAttack) // feed the stack with the trojans
                {
                    trojans.Push(item);
                }


                if (i % 3 == 0) // every thrid wave we add to the Spartans one integer
                {
                    Queue<int> temp = new Queue<int>();
                    int spartan = int.Parse(Console.ReadLine());
                    while (spartans.Count() > 0)
                    {
                        temp.Enqueue(spartans.Pop());
                    }
                    temp.Enqueue(spartan);

                    spartans = new Stack<int>(temp.Reverse());
                    temp = new Queue<int>();
                }

                while (spartans.Count() > 0 && trojans.Count() > 0)
                {
                    if (spartans.Peek() > trojans.Peek())    //fight
                    {
                        spartans.Push(spartans.Pop() - trojans.Pop()); // see if it will work ???
                    }

                    else if (spartans.Peek() == trojans.Peek()) // warrior dies and the plate is destroyed
                    {
                        spartans.Pop();
                        trojans.Pop();

                    }

                    else if (spartans.Peek() < trojans.Peek())
                    {
                        trojans.Push(trojans.Pop() - spartans.Pop());
                    }
                }


                if (spartans.Count() == 0)  // zero left in Spartans ????
                {
                    Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                    break; //???
                }
            }

            if (spartans.Count() > 0)
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack. ");
                Console.Write("Plates left: ");
                Console.WriteLine(String.Join(", ", spartans));
            }

            if (trojans.Count() > 0)
            {
                Console.Write("Warriors left: ");
                Console.WriteLine(String.Join(", ", trojans));
            }
        }
    }
}