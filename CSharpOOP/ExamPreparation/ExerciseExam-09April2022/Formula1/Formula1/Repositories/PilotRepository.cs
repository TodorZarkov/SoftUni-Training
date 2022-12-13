namespace Formula1.Repositories
{
    using Contracts;

    using System.Collections.Generic;
    using Formula1.Models.Contracts;

    internal class PilotRepository : IRepository<IPilot>
    {
        List<IPilot> pilots;

        public PilotRepository()
        {
            pilots = new List<IPilot>();
        }
        public IReadOnlyCollection<IPilot> Models => pilots.AsReadOnly();

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
