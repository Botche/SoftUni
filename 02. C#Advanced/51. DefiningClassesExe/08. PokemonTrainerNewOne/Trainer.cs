using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainerNewOne
{
    public class Trainer
    {
        private string name;
        private int numberOfBadges;
        private List<Pokemon> pokemons;

        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public Trainer()
        {
            NumberOfBadges = 0;
            Pokemons = new List<Pokemon>();
        }

        public void AddPokemon(Pokemon pokemon)
        {
            pokemons.Add(pokemon);
        }
    }
}
