namespace SoftUniBazar.Services.Interfaces
{
    using SoftUniBazar.Models.Ad;
    using SoftUniBazar.Models.Category;

    public interface ICategoryService
    {
        Task<ICollection<CategorySelectViewModel>> AllForSelectAsync();

        Task<bool> ValidId(int categoryId);
    }
}
