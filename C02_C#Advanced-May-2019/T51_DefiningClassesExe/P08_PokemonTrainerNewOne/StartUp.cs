using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainerNewOne
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            CollectTrainers(trainers);

            AddBadgesAndRemovePokemons(trainers);
        }

        private static void AddBadgesAndRemovePokemons(List<Trainer> trainers)
        {
            string input = null;

            while ((input = Console.ReadLine()) != "End")
            {
                string element = input;
                int countOfPokemons = 0;

                CheckForEveryTrainer(trainers, element, countOfPokemons);
            }
            var sortedTrainers = trainers.OrderByDescending(x => x.NumberOfBadges);
            foreach (var trainer in sortedTrainers)
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }

        private static void CheckForEveryTrainer(List<Trainer> trainers, string element, int countOfPokemons)
        {
            foreach (var trainer in trainers)
            {
                countOfPokemons = trainer.Pokemons.Where(x => x.Element == element).Count();
                if (countOfPokemons != 0)
                {
                    trainer.NumberOfBadges++;
                }
                else
                {
                    for (int i = trainer.Pokemons.Count - 1; i >= 0; i--)
                    {
                        Pokemon pokemon = trainer.Pokemons[i];

                        pokemon.Health -= 10;
                        if (pokemon.Health <= 0)
                        {
                            trainer.Pokemons.Remove(pokemon);
                        }
                    }
                }
            }

        }

        private static void CollectTrainers(List<Trainer> trainers)
        {
            string[] input = new string[4];

            while ((input = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries))[0] != "Tournament")
            {
                string trainerName = input[0];
                string pokemonName = input[1];
                string pokemonElement = input[2];
                double pokemonHealth = double.Parse(input[3]);

                Pokemon pokemon = new Pokemon()
                {
                    Name = pokemonName,
                    Element = pokemonElement,
                    Health = pokemonHealth
                };

                Trainer trainer = new Trainer()
                {
                    Name = trainerName,
                    Pokemons = new List<Pokemon>()
                };

                bool isInTrainersYet = trainers.Exists(x => x.Name == trainer.Name);
                if (!isInTrainersYet)
                {
                    trainers.Add(trainer);
                }
                var tra = trainers.Where(x => x.Name == trainer.Name).FirstOrDefault();
                var index = trainers.IndexOf(tra);

                trainers[index].Pokemons.Add(pokemon);

            }
        }
    }
}
