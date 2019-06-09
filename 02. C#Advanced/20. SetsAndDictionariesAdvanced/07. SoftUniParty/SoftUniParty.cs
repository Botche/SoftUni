using System;
using System.Collections.Generic;

namespace _07._SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipGuestReservations = new HashSet<string>();
            HashSet<string> regularGuestsReservations = new HashSet<string>();

            int lengthOfReservations = 8;

            string input = Console.ReadLine();
            while (input!="PARTY")
            {
                string guestNumber = input;

                if (char.IsDigit(guestNumber[0]))
                {
                    vipGuestReservations.Add(guestNumber);
                }
                else
                {
                    regularGuestsReservations.Add(guestNumber);
                }
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input!="END")
            {
                string guestNumber = input;
                if (char.IsDigit(guestNumber[0]))
                {
                    vipGuestReservations.Remove(guestNumber);
                }
                else
                {
                    regularGuestsReservations.Remove(guestNumber);
                }

                input = Console.ReadLine();
            }
            int countOfGuestThatDidntCome =
                vipGuestReservations.Count+regularGuestsReservations.Count;
            Console.WriteLine(countOfGuestThatDidntCome);

            foreach (var guest in vipGuestReservations)
            {
                Console.WriteLine(guest);
            }
            foreach (var guest in regularGuestsReservations)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
