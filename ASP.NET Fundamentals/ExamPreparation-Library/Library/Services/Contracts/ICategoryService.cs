namespace Library.Services.Contracts
{
    using Library.Models.Category;

    public interface ICategoryService
    {
        Task<bool> ExistAsync(int categoryId);

        Task<ICollection<SelectCategoryDto>> AllForSelectAsync();
    }
}
