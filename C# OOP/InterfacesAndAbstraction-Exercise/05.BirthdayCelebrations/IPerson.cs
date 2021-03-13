using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BirthdayCelebrations
{
    public interface IPerson : IIndentify
    {
        string Name { get; }

        string Age { get; }
    }
}
