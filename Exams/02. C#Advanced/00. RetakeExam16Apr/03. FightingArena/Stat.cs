﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _03._FightingArena
{
    class Stat
    {
        private int strength;
        private int flexibility;
        private int agility;
        private int skills;
        private int intelligence;

        public int Strength { get; set; }
        public int Flexibility { get; set; }
        public int Agility { get; set; }
        public int Skills { get; set; }
        public int Intelligence { get; set; }

        public Stat(int strength, int flexibility, int agility, int skills, int intelligence)
        {
            Strength = strength;
            Flexibility = flexibility;
            Agility = agility;
            Skills = skills;
            Intelligence = intelligence;
        }
    }
}
