namespace Library.Services
{
    using Library.Data;
    using Library.Models.Category;
    using Library.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CategoryService : ICategoryService
    {
        private readonly LibraryDbContext dbContext;
        public CategoryService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<ICollection<SelectCategoryDto>> AllForSelectAsync()
        {
            var categories = await dbContext.Categories
                .AsNoTracking()
                .Select(c => new SelectCategoryDto
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToArrayAsync();

            return categories;
        }

        public async Task<bool> ExistAsync(int categoryId)
        {
            var category = await dbContext.Categories
                .FindAsync(categoryId);

            if (category == null)
            {
                return false;
            }

            return true;
        }
    }
}
