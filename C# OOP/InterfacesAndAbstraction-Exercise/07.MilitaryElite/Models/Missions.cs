using System;
using System.Collections.Generic;
using System.Text;
using _07.MilitaryElite.Contracts;
using _07.MilitaryElite.Enums;

namespace _07.MilitaryElite.Models
{
    public class Missions : IMissions
    {

        private State state;

        public Missions(string codeName, string state)
        {
            CodeName = codeName;
            State = state;
        }

        public string CodeName { get; private set; }

        public string State
        {
            get => state.ToString();
            private set
            {
                if (Enum.TryParse<State>(value, out state) == false)
                {
                    throw new ArgumentException();
                }
            }
        }

        public void CompleteMission()
        {
            if (this.state == Enums.State.Finished)
            {
                throw new ArgumentException();
            }

            this.state = Enums.State.Finished;
        }


        public override string ToString()
        {
            return $"  Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
