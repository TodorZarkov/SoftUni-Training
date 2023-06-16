using Library.ViewModels.Category;

namespace Library.Services.Contracts
{
    public interface ICategoryService
    {
        Task<ICollection<SelectCategoryViewModel>> GetAllCategoriesAsync();

        Task<bool> HasCategoryAsync(int categoryId);
    }
}
