namespace ChristmasPastryShop.Repositories
{
    using System.Collections.Generic;

    using ChristmasPastryShop.Models.Delicacies.Contracts;
    using ChristmasPastryShop.Repositories.Contracts;

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
