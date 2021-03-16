using System;
using System.Collections.Generic;
using System.Text;
using _07.MilitaryElite.Contracts;
using _07.MilitaryElite.Enums;


namespace _07.MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName, salary)
        {
            Privates = new List<ISoldier>();
        }

        public ICollection<ISoldier> Privates { get; private set; }

        
        public void AddPrivate(ISoldier @private)
        {
            Privates.Add(@private);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");

            foreach (var item in Privates)
            {
                sb.AppendLine($" {item.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
