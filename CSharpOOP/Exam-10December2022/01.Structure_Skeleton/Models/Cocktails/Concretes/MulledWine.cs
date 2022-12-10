namespace ChristmasPastryShop.Models.Cocktails.Concretes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class MulledWine : Cocktail
    {
        public MulledWine(string cocktailName, string size) : base(cocktailName, size, 13.50)
        {
        }
    }
}
