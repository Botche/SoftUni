using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;

namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;

        public Player(ICardRepository cardRepository, string username, int health)
        {
            CardRepository = cardRepository;
            Username = username;
            Health = health;
        }

        public ICardRepository CardRepository { get; }

        public string Username
        {
            get => username;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Player's username cannot be null or an empty string.");
                }
                username = value;
            }
        }

        public int Health
        {
            get => health;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player's health bonus cannot be less than zero. ");
                }
                health = value;
            }
        }

        public bool IsDead
        {
            get
            {
                if (Health == 0)
                {
                    return true;
                }

                return false;
            }
        }

        public void TakeDamage(int damagePoints)
        {
            if (damagePoints < 0)
            {
                throw new ArgumentException("Damage points cannot be less than zero.");
            }

            if (Health - damagePoints < 0)
            {
                Health = 0;
            }
            else
            {
                Health -= damagePoints;
            }
        }
    }
}
