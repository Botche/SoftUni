using System;
using System.Collections.Generic;
using System.Text;

namespace _03._FightingArena
{
    class Weapon
    {
        private int size;
        private int solidity;
        private int sharpness;

        public int Size { get; set; }
        public int Solidity { get; set; }
        public int Sharpness { get; set; }

        public Weapon(int size, int solidity, int sharpness)
        {
            Size = size;
            Solidity = solidity;
            Sharpness = sharpness;
        }
    }
}
