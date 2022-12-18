namespace PlanetWars.Models.Weapons.Concretes
{

    public class NuclearWeapon : Weapon
    {
        public NuclearWeapon(int destructionLevel) : base(destructionLevel, 15)
        {
        }
    }
}
