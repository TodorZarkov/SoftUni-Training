namespace ChristmasPastryShop.Repositories
{
    using ChristmasPastryShop.Models.Delicacies.Contracts;
    using ChristmasPastryShop.Repositories.Contracts;
    using System.Collections.Generic;

    public class DelicacyRepository : IRepository<IDelicacy>
    {
        readonly List<IDelicacy> delicacies;

        public DelicacyRepository()
        {
            delicacies = new List<IDelicacy>();
        }

        //TODO may be bether to create new list
        public IReadOnlyCollection<IDelicacy> Models => delicacies;

        public void AddModel(IDelicacy model)
        {
            delicacies.Add(model);
        }
    }
}
