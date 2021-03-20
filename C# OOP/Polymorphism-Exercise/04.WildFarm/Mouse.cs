using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public class Mouse : Mammal
    {

        private const double weightModifier = 0.10;
        private static HashSet<string> allowedFoods = new HashSet<string>
        {

            nameof(Vegetable),
            nameof(Fruit),
        };

        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, allowedFoods, weightModifier, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
