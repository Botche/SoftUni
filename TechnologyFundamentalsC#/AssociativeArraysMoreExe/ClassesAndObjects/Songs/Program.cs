using System;
using System.Collections.Generic;
using System.Linq;

namespace Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numSongs = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();
            for (int i = 0; i < numSongs; i++)
            {
                string[] data = Console.ReadLine()
                    .Split("_");

                string type = data[0];
                string name = data[1];
                string time = data[2];

                Song song = new Song();
                song.TypeList = type;
                song.Name = name;
                song.Time = time;

                songs.Add(song);
            }
            string filter = Console.ReadLine();
            if (filter == "all")
            {
                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                List<Song> filtered = songs.
                    Where(x => x.TypeList == filter)
                    .ToList();
                foreach (Song song in filtered)
                {
                    Console.WriteLine(song.Name);
                }
            }
        }
        class Song
        {
            public string TypeList;
            public string Name;
            public string Time;
            
        }
    }
}
