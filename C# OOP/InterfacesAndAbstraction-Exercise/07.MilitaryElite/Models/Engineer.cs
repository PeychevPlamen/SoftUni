using System;
using System.Collections.Generic;
using System.Text;
using _07.MilitaryElite.Contracts;
using _07.MilitaryElite.Enums;

namespace _07.MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string id, string firstName, string lastName, decimal salary, string corp) 
            : base(id, firstName, lastName, salary, corp)
        {
            Repairs = new List<IRepair>();
        }

        public ICollection<IRepair> Repairs { get; private set; }

        public void AddRepairs (Repair @repair)
        {
            Repairs.Add(@repair);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Repairs:");

            foreach (var item in Repairs)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
