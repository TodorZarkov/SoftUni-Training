using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        public Cake(string name) : base(name, 5m, 250, 1000)
        {

        }
        //public Cake(string name, decimal price, double grams, double calories) : base(name, price, grams, calories)
        //{

        //}
    }
}
