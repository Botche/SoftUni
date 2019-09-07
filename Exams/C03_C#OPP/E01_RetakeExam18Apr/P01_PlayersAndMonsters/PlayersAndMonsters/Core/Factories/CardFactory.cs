using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PlayersAndMonsters.Core.Factories
{
    public class CardFactory : ICardFactory
    {
        private const string cardExtension = "Card";
        public ICard CreateCard(string type, string name)
        {
            var typeOfCard = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type + cardExtension);

            if (typeOfCard==null)
            {
                throw new ArgumentException("");
            }

            var card = (ICard)Activator.CreateInstance(typeOfCard, name);

            return card;
        }
    }
}
