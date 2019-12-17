using System;
using System.IO;
using System.Collections.Generic;

using P01_Singleton.Interfaces;

namespace P01_Singleton.Models
{
    public class SingletonDataContainer : ISigletonContainer
    {
        private Dictionary<string, int> _capitals = new Dictionary<string, int>();

        public SingletonDataContainer()
        {
            Console.WriteLine("Initialize singleton object");

            var elements = File.ReadAllLines("capitals.txt");
            for (int i = 0; i < elements.Length; i++)
            {
                _capitals.Add(elements[i], int.Parse(elements[i + 1]));
            }
        }

        public int GetPopulation(string name)
        {
            return _capitals[name];
        }

        private static SingletonDataContainer instance;

        public static SingletonDataContainer Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (instance)
                        if (instance == null)
                        {
                            instance = new SingletonDataContainer();
                        }
                }

                return instance;
            }
        }
    }
}
