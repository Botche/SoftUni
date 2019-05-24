using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceOfBullet = int.Parse(Console.ReadLine());
            int sizeOfGunBarrel = int.Parse(Console.ReadLine());
            int[] inputBullets = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            int[] inputLocks = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            int intelligence = int.Parse(Console.ReadLine());

            Queue<int> locks = new Queue<int>(inputLocks);
            Stack<int> bullets = new Stack<int>(inputBullets);

            int count = 0;
            while (locks.Count!=0 && bullets.Count!=0)
            {
                int bullet = bullets.Peek();
                int lockF= locks.Peek();

                if(bullet<=lockF)
                {
                    Console.WriteLine("Bang!");
                    bullets.Pop();
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                    bullets.Pop();
                }
                count++;
                if (count % sizeOfGunBarrel==0 && bullets.Count!=0)
                {
                    Console.WriteLine("Reloading!");
                }
            }
            if (bullets.Count == 0 && locks.Count>0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligence - count * priceOfBullet}");
            }
        }
    }
}
