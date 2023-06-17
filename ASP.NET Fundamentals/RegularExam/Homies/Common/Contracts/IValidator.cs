namespace Homies.Common.Contracts
{
    public interface IValidator
    {
        public bool IsSecondAfterFirst(string firstDate, string secondDate);
    }
}
