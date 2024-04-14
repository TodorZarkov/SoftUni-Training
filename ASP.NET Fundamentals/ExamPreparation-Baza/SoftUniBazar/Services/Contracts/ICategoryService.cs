namespace SoftUniBazar.Services.Contracts
{
    using Models.Category;

    public interface ICategoryService
    {
        Task<ICollection<CategoryViewModel>> AllAsync();

        Task<bool> ExistAsync(int categoryId);
    }
}
