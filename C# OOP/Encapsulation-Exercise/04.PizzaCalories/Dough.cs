using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private const int minWeight = 1;
        private const int maxWeight = 200;

        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public string FlourType
        {
            get => flourType;
            private set 
            {
                string valueAsLower = value.ToLower();

                if (valueAsLower != "white" && valueAsLower != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                flourType = value; 
            }
        }

        public string BakingTechnique
        {
            get => bakingTechnique;
            private set 
            {
                string valueAsLower = value.ToLower();

                if (valueAsLower != "crispy" && valueAsLower != "chewy" && valueAsLower != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                bakingTechnique = value; 
            }
        }

        public int Weight
        {
            get => weight;
            private set 
            {
                if (value < minWeight || value > maxWeight)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{minWeight}..{maxWeight}].");
                }
                weight = value; 
            }
        }

        public double GetCallories()
        {
            double flourTypeModifier = GetFlourTypeModifier();
            double bakingTechniqueModifier = GetBakingTechniqueModifier();

            return Weight * 2 * flourTypeModifier * bakingTechniqueModifier;
        }

        private double GetBakingTechniqueModifier()
        {
            string bakingTechniqueLower = BakingTechnique.ToLower();

            if (bakingTechniqueLower == "crispy")
            {
                return 0.9;
            }
            if (bakingTechniqueLower == "chewy")
            {
                return 1.1;
            }

            return 1;
        }

        private double GetFlourTypeModifier()
        {
            string flourTypeLower = FlourType.ToLower();

            if (flourTypeLower == "white")
            {
                return 1.5;
            }
            
                return 1;
            
        }
    }
}
