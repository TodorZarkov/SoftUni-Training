namespace UniversityCompetition.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UniversityCompetition.Models.Contracts;
    using UniversityCompetition.Repositories.Contracts;

    public class SubjectRepository : IRepository<ISubject>
    {
        private ICollection<ISubject> subjects;

        public SubjectRepository()
        {
            subjects = new List<ISubject>();
        }

        public IReadOnlyCollection<ISubject> Models => (IReadOnlyCollection<ISubject>)subjects;

        public void AddModel(ISubject model)
        {
            subjects.Add(model);
        }

        public ISubject FindById(int id)
        {
            return subjects.FirstOrDefault(s => s.Id == id);
        }

        public ISubject FindByName(string name)
        {
            return subjects.FirstOrDefault(s => s.Name == name);
        }
    }
}
