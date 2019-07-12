﻿using MilitaryElite.Interfaces;
using P06_MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName, int codeNumber)
            :base(id,firstName,lastName)
        {
            CodeNumber = codeNumber;
        }
        public int CodeNumber { get; }

        public override string ToString()
        {
            return base.ToString().TrimEnd() +Environment.NewLine+$"Code Number: {CodeNumber}";
        }
    }
}
