using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Contracts
{
    public interface ICommando
    {
        ICollection<IMissions> Missions { get; }
    }
}

namespace _07.MilitaryElite
{
    public interface Interface1
    {
    }
}