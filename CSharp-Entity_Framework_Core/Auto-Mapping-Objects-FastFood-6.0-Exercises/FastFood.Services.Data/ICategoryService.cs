namespace FastFood.Services.Data;

using FastFood.Core.ViewModels.Categories;

public interface ICategoryService
{
    Task CreateAsync(CreateCategoryInputModel model);

    Task<IEnumerable<CategoryAllViewModel>> GetAllAsync();
}
