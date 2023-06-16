using Library.Data;
using Library.Services.Contracts;
using Library.ViewModels.Category;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly LibraryDbContext dbContext;

        public CategoryService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<SelectCategoryViewModel>> GetAllCategoriesAsync()
        {
            var categories = await dbContext.Categories
                .Select(c => new SelectCategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToArrayAsync();

            return categories;
        }

        public async Task<bool> HasCategoryAsync(int categoryId)
        {
            var hasCategory = await dbContext.Categories
                .FindAsync(categoryId);

            if (hasCategory == null)
            {
                return false;
            }

            return true;
        }
    }
}
