namespace UniversityCompetition.Repositories
{
    
    using System.Collections.Generic;
    using System.Linq;
    using UniversityCompetition.Models.Contracts;
    using UniversityCompetition.Repositories.Contracts;

    public class UniversityRepository : IRepository<IUniversity>
    {
        private ICollection<IUniversity> universities;

        public UniversityRepository()
        {
            universities = new List<IUniversity>();
        }

        public IReadOnlyCollection<IUniversity> Models => (IReadOnlyCollection<IUniversity>)universities;

        public void AddModel(IUniversity model)
        {
            universities.Add(model);
        }

        public IUniversity FindById(int id)
        {
            return universities.FirstOrDefault(s => s.Id == id);
        }

        public IUniversity FindByName(string name)
        {
            return universities.FirstOrDefault(s => s.Name == name);
        }
    }
}
