namespace Homies.Services
{
    using Homies.Data;
    using Homies.Models.Type;
    using Homies.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TypeService : ITypeService
    {
        private readonly HomiesDbContext dbContext;

        public TypeService(HomiesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<ICollection<TypeSelectViewModel>> GetAllTypesForSelectAsync()
        {
            var allTypes = await dbContext.Types
                .Select(t => new TypeSelectViewModel()
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToArrayAsync();

            return allTypes;
        }

        public async Task<bool> IsValidType(int typeId)
        {
            return await dbContext.Types.AnyAsync(t => t.Id == typeId);
        }
    }
}
