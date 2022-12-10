namespace ChristmasPastryShop.Models.Cocktails.Concretes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Hibernation : Cocktail
    {
        public Hibernation(string cocktailName, string size) : base(cocktailName, size, 10.50)
        {
        }
    }
}
