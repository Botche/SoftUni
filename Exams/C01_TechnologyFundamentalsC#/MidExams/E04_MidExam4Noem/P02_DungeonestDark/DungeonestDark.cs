using System;

namespace DungeonestDark
{
    class Program
    {
        static void Main(string[] args)
        {
            int health = 100, coins = 0;
            string[] rooms = Console.ReadLine().Split("|");
            for (int i = 0; i < rooms.Length; i++)
            {
                string[] room = rooms[i].Split(" ");
                string command = room[0];
                int number = int.Parse(room[1]);
                if (command == "potion")
                {
                    health += number;
                    if (health > 100)
                    {
                        Console.WriteLine($"You healed for { 100 - health + number} hp.");
                        health = 100;
                    }
                    else
                        Console.WriteLine($"You healed for {number} hp.");
                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if (command == "chest")
                {
                    coins += number;
                    Console.WriteLine($"You found {number} coins.");
                }
                else
                {
                    health -= number;
                    if (health <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {command}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        break;
                    }
                    else
                        Console.WriteLine($"You slayed {command}.");
                }
            }
            if (health > 0)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Coins: {coins}");
                Console.WriteLine($"Health: {health}");
            }
        }
    }
}
