using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Players
{
    public class MainPlayer : Player
    {
        private const string theName = "Tommy Vercetti";
        private const int initialLifePoints = 100;

        public MainPlayer()
            : base(theName, initialLifePoints)
        {
        }
    }
}
