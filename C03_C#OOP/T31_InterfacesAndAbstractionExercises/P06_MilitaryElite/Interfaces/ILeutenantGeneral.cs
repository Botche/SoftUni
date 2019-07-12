using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    public interface ILeutenantGeneral:IPrivate
    {
        IReadOnlyCollection<Private> Privates { get; }
        void AddPrivate(Private priv);
    }
}
