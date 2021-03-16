using System;
using System.Collections.Generic;
using System.Text;
using _07.MilitaryElite.Contracts;
using _07.MilitaryElite.Enums;

namespace _07.MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private Corp corp;

        protected SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corp) 
            : base(id, firstName, lastName, salary)
        {
            Corps = corp;
        }

        public string Corps 
        {
            get => corp.ToString();
            private set
            {
                if (Enum.TryParse<Corp>(value, out corp) == false)
                {
                    throw new ArgumentException();
                }
            }
        }
        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Corps: {Corps}";
        }

    }
}
