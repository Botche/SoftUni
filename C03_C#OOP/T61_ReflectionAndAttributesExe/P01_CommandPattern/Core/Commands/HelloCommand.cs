﻿using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core.Commands
{
    class HelloCommand : ICommand
    {
        public string Execute (string[] args)
        {
            return $"Hello {args[0]}";
        }
    }
}
