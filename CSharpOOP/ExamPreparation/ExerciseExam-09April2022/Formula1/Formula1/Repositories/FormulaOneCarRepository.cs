namespace Formula1.Repositories
{
    
    using System.Collections.Generic;

    using Models.Contracts;
    using Contracts;

    internal class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        readonly List<IFormulaOneCar> models;

        public FormulaOneCarRepository()
        {
            models = new List<IFormulaOneCar>();
        }
        public IReadOnlyCollection<IFormulaOneCar> Models
        {
            get
            {
                return models;
            }
        }

        public void Add(IFormulaOneCar model)
        {
            models.Add(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            return models.Find(m => m.Model == name);
        }

        public bool Remove(IFormulaOneCar model)
        {
            return models.Remove(model);
        }
    }
}
