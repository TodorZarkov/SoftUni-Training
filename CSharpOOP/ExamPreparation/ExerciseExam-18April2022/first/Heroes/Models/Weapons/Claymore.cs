namespace Heroes.Models.Weapons
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Text;

    public class Claymore : Weapon
    {
        private const int damage = 20;

        public Claymore(string name, int durability) : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            int resultDurability = Durability - 1;
            if(resultDurability <= 0)
            {
                return 0;
            }

            Durability = resultDurability;
            return damage;
        }
    }
}
