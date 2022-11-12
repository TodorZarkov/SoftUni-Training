
namespace _03.Raiding
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Warrior : BaseHero
    {
     

        public Warrior(string name) : base(name)
        {
            Power = 100;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
