using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double DefaultCakeGrams = 250;
        private const double DefaulCakeCalories = 1000;
        private const decimal DefaultCakePrice = 5.0M;

        public Cake(string name) 
            : base(name, DefaultCakePrice, DefaultCakeGrams, DefaulCakeCalories)
        {

        }
    }
}
