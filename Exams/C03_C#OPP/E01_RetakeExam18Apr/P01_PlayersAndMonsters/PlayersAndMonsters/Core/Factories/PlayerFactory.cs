using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PlayersAndMonsters.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            var typeOfPlayer = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);

            if (typeOfPlayer==null)
            {
                throw new ArgumentException("");
            }
            var cardRepository = new CardRepository();

            var player = (IPlayer)Activator.CreateInstance(typeOfPlayer, cardRepository, username);

            return player;
        }
    }
}
