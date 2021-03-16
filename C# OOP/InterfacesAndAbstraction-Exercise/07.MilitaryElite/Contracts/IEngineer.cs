using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Contracts
{
    public interface IEngineer
    {
        ICollection<IRepair> Repairs { get; }
    }
}
