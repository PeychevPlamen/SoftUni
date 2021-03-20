using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public class Tiger : Feline
    {

        private const double weightModifier = 1;
        private static HashSet<string> allowedFoods = new HashSet<string>
        {
            nameof(Meat),

        };

        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight,  allowedFoods, weightModifier, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
