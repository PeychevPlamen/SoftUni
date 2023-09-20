using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
    public class Engine
    {
        //private int engineSpeed;
        //private int enginePower;

        public Engine(int engineSpeed, int enginePower)
        {
            this.EngineSpeed = engineSpeed;
            this.EnginePower = enginePower;
        }
        public int EngineSpeed { get; set; }

        public int EnginePower { get; set; }
    }
}
