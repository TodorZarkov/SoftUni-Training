
namespace _03.Raiding
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Rogue : BaseHero
    {
       

        public Rogue(string name) : base(name)
        {
            Power = 80;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
