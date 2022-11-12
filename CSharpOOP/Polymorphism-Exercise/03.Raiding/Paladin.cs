
namespace _03.Raiding
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Paladin : BaseHero
    {
      

        public Paladin(string name) : base(name)
        {
            Power = 100;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
