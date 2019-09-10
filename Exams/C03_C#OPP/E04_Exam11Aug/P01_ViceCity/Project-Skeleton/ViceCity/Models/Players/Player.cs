using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Models.Players
{
    public abstract class Player : IPlayer
    {
        private int lifePoints;
        private string name;

        private Player()
        {
            GunRepository = new Repository();
        }

        protected Player(string name, int lifePoints)
            :this()
        {
            Name = name;
            LifePoints = lifePoints;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(Player),"Player's name cannot be null or a whitespace!");
                }

                name = value;
            }
        }

        public bool IsAlive
        {
            get
            {
                if (LifePoints == 0)
                {
                    return false;
                }

                return true;
            }
        }

        public IRepository<IGun> GunRepository { get; }

        public int LifePoints
        {
            get => lifePoints;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player life points cannot be below zero!");
                }

                lifePoints = value;
            }
        }

        public void TakeLifePoints(int points)
        {
            if (LifePoints - points < 0)
            {
                LifePoints = 0;
            }
            else
            {
                LifePoints -= points;
            }
        }
    }
}
