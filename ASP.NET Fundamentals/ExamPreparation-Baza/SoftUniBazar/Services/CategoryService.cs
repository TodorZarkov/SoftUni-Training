namespace SoftUniBazar.Services
{
    using Data;
    using Models.Category;
    using Microsoft.EntityFrameworkCore;
    using SoftUniBazar.Services.Contracts;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CategoryService : ICategoryService
    {
        private readonly BazarDbContext dbContext;

        public CategoryService(BazarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<CategoryViewModel>> AllAsync()
        {
            var categories = await dbContext.Categories
                .AsNoTracking()
                .Select(t => new CategoryViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToArrayAsync();

            return categories;
        }

        public async Task<bool> ExistAsync(int categoryId)
        {
            Data.Category? category = await dbContext.Categories.FindAsync(categoryId);

            if (category == null)
            {
                return false;
            }

            return true;
        }
    }
}
