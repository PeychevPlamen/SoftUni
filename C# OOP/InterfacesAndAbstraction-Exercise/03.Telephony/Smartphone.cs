using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    public class Smartphone : ICallable, IBrowseable
    {
        public string Call(string number)
        {
            return $"Calling... {number}";
        }
        public string Browse(string url)
        {
            return $"Browsing: {url}!";

        }
    }
}
