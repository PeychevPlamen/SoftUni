using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Contracts
{
    public interface IMissions
    {
        string CodeName { get; }

        string State { get; }

        void CompleteMission();
    }
}
