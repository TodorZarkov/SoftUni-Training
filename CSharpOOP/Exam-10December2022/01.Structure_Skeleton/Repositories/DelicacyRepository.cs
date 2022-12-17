namespace ChristmasPastryShop.Repositories
{
    using System.Collections.Generic;

    using ChristmasPastryShop.Models.Delicacies.Contracts;
    using ChristmasPastryShop.Repositories.Contracts;

    public class DelicacyRepository : IRepository<IDelicacy>
    {
        private readonly ICollection<IDelicacy> delicacies;

        public DelicacyRepository()
        {
            delicacies = new HashSet<IDelicacy>();
        }

        
        public IReadOnlyCollection<IDelicacy> Models => (IReadOnlyCollection<IDelicacy>)delicacies;

        public void AddModel(IDelicacy model)
        {
            delicacies.Add(model);
        }
    }
}
