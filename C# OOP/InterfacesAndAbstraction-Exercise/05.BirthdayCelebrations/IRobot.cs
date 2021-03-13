using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BirthdayCelebrations
{
    public interface IRobot : IIndentify
    {
        string Model { get; }
    }
}
