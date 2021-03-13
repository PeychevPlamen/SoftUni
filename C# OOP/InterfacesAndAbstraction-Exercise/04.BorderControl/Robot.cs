using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public class Robot : IName, IIdentify
    {
        public Robot(string name, string id)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; private set; }

        public string Id { get; private set; }
    }
}
