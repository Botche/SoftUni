using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private List<IPlayer> players;

        public PlayerRepository()
        {
            players = new List<IPlayer>();
        }

        public int Count => Players.Count;

        public IReadOnlyCollection<IPlayer> Players => players;

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            var playerToCheck = players.FirstOrDefault(p => p.Username == player.Username);
            if (playerToCheck != null)
            {
                throw new ArgumentException($"Player {playerToCheck.Username} already exists!");
            }

            players.Add(player);
        }

        public IPlayer Find(string username)
        {
            return players.FirstOrDefault(p => p.Username == username);
        }

        public bool Remove(IPlayer player)
        {
            var playerToRemove = players.FirstOrDefault(p => p.Username == player.Username);

            if (playerToRemove == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            players.Remove(playerToRemove);

            return true;
        }
    }
}
