namespace Formula1.Repositories
{
    using System;
    using System.Collections.Generic;

    using Formula1.Models.Contracts;
    using Formula1.Repositories.Contracts;

    internal class RaceRepository : IRepository<IRace>
    {
        List<IRace> races;

        public RaceRepository()
        {
            races = new List<IRace>();
        }
        public IReadOnlyCollection<IRace> Models => races.AsReadOnly();

        public void Add(IRace model)
        {
            races.Add(model);
        }

        public IRace FindByName(string name)
        {
            return races.Find(r => r.RaceName == name);
        }

        public bool Remove(IRace model)
        {
            return races.Remove(model);
        }
    }
}
