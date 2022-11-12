
namespace _03.Raiding
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public abstract class BaseHero : IBaseHero
    {
        string name;
        protected BaseHero(string name)
        {
            Name = name;
        }

        public string Name
        {
            get { return name; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name cannot be empty");
                }
                name = value;
            }
        }
        public decimal Power { get; protected set; }



        public abstract string CastAbility();
    }
}
