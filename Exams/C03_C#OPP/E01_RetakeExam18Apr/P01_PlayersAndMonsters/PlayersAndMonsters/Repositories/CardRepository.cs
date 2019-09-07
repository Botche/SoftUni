using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private List<ICard> cards;
        public CardRepository()
        {
            cards = new List<ICard>();
        }
        public int Count => Cards.Count;

        public IReadOnlyCollection<ICard> Cards => cards;

        public void Add(ICard card)
        {
            if (card==null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            var cardToCheck = cards.FirstOrDefault(c => c.Name == card.Name);
            if (cardToCheck!=null)
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }

            cards.Add(card);
        }

        public ICard Find(string name)
        {
            return cards.FirstOrDefault(c => c.Name == name);
        }

        public bool Remove(ICard card)
        {
            var cardToRemove = cards.FirstOrDefault(c => c.Name == card.Name);

            if (cardToRemove == null)
            {
                throw new ArgumentException("Card cannot be null");
            }

            cards.Remove(cardToRemove);

            return true;
        }
    }
}
