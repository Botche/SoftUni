using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonDontGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemonDis = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToList();
            int index = 0;
            int sum = 0;
            while (pokemonDis.Count>0)
            {
                index = int.Parse(Console.ReadLine());
                int numForDeAndAs = 0;
                if (index < 0)
                {
                    numForDeAndAs = pokemonDis[0];
                    pokemonDis.RemoveAt(0);
                    pokemonDis.Insert(0, pokemonDis[pokemonDis.Count - 1]);
                    //pokemonDis.RemoveAt(pokemonDis.Count - 1);
                    for (int i = 0; i < pokemonDis.Count; i++)
                    {
                        if (pokemonDis[i] <= numForDeAndAs)
                            pokemonDis[i] += numForDeAndAs;
                        else
                            pokemonDis[i] -= numForDeAndAs;
                    }
                }
                else if(index>=pokemonDis.Count)
                {
                    numForDeAndAs = pokemonDis[pokemonDis.Count - 1];
                    pokemonDis.Insert(pokemonDis.Count - 1, pokemonDis[0]);
                    pokemonDis.RemoveAt(pokemonDis.Count - 1);
                    
                    //pokemonDis.RemoveAt(0);
                    for (int i = 0; i < pokemonDis.Count; i++)
                    {
                        if (pokemonDis[i] <= numForDeAndAs)
                            pokemonDis[i] += numForDeAndAs;
                        else
                            pokemonDis[i] -= numForDeAndAs;
                    }
                }
                else
                {
                    numForDeAndAs = pokemonDis[index];
                    pokemonDis.RemoveAt(index);
                    for (int i = 0; i < pokemonDis.Count; i++)
                    {
                        if (pokemonDis[i] <= numForDeAndAs)
                            pokemonDis[i] += numForDeAndAs;
                        else
                            pokemonDis[i] -= numForDeAndAs;
                    }
                }
                sum += numForDeAndAs;
                //Console.WriteLine(string.Join(" ",pokemonDis));
            }
            Console.WriteLine(sum);
        }
    }
}
