namespace SoftUniBazar.Services
{
    using Microsoft.EntityFrameworkCore;
    using SoftUniBazar.Data;
    using SoftUniBazar.Models.Category;
    using SoftUniBazar.Services.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CategoryService : ICategoryService
    {
        private readonly BazarDbContext dbContext;

        public CategoryService(BazarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<ICollection<CategorySelectViewModel>> AllForSelectAsync()
        {
            ICollection<CategorySelectViewModel> categories = await dbContext.Categories
                .AsNoTracking()
                .Select(c => new CategorySelectViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToArrayAsync();

            return categories;
        }

        public async Task<bool> ValidId(int categoryId)
        {
                bool result = await dbContext.Categories
                .AsNoTracking()
                .AnyAsync(c => c.Id == categoryId);

            return result;
        }
    }
}
