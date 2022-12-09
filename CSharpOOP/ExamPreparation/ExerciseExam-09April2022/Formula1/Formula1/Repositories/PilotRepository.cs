namespace Formula1.Repositories
{
    using Contracts;

    using System.Collections.Generic;
    using Formula1.Models.Contracts;

    internal class PilotRepository : IRepository<IPilot>
    {
        readonly List<IPilot> pilots;
        public IReadOnlyCollection<IPilot> Models => pilots;

        public void Add(IPilot model)
        {
            pilots.Add(model);
        }

        public IPilot FindByName(string name)
        {
            return pilots.Find(p => p.FullName == name);
        }

        public bool Remove(IPilot model)
        {
            return pilots.Remove(model);
        }
    }
}
