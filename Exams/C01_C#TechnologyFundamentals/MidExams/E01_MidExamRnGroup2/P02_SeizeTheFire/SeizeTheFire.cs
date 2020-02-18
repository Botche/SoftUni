using System;
using System.Collections.Generic;

namespace SeizeTheFire
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fires = Console.ReadLine().Split("#");

            int water = int.Parse(Console.ReadLine());
            List<int> cells = new List<int>();
            double effort = 0;
            double TotalFire = 0;
            foreach (var fire in fires)
            {
                string[] data = fire.Split(" = ");
                string cell = data[0];
                int fireStat = int.Parse(data[1]);

                switch (cell)
                {
                    case "High":
                        if (fireStat <= 125 && fireStat > 80)
                        {
                            if (water >= fireStat)
                            {
                                effort += fireStat * 0.25;
                                TotalFire += fireStat;
                                cells.Add(fireStat);
                                water -= fireStat;
                            }
                        }
                        break;
                    case "Medium":
                        if (fireStat <= 80 && fireStat > 50)
                        {
                            if (water >= fireStat)
                            {
                                effort += fireStat * 0.25;
                                TotalFire += fireStat;
                                cells.Add(fireStat);
                                water -= fireStat;
                            }
                        }
                        break;
                    case "Low":
                        if (fireStat <= 50 && fireStat >= 1)
                        {
                            if (water >= fireStat)
                            {
                                effort += fireStat * 0.25;
                                TotalFire += fireStat;
                                cells.Add(fireStat);
                                water -= fireStat;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("Cells:");
            foreach (var cell in cells)
            {
                Console.WriteLine($" - {cell}");
            }
            Console.WriteLine($"Effort: {effort:f2}");
            Console.WriteLine($"Total Fire: {TotalFire}");
        }
    }
}
