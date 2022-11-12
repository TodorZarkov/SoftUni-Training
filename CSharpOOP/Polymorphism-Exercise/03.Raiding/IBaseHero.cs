namespace _03.Raiding
{
    public interface IBaseHero
    {
        string Name { get; }
        decimal Power { get; }

        string CastAbility();
    }
}