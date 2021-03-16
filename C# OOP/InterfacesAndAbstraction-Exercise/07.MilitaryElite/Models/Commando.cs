using System;
using System.Collections.Generic;
using System.Text;
using _07.MilitaryElite.Contracts;
using _07.MilitaryElite.Enums;

namespace _07.MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string id, string firstName, string lastName, decimal salary, string corp) 
            : base(id, firstName, lastName, salary, corp)
        {
            Missions = new List<IMissions>();
        }

        public ICollection<IMissions> Missions { get; private set; }

        public void AddMission (Missions missions)
        {
            Missions.Add(missions);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Missions:");

            foreach (var item in Missions)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
