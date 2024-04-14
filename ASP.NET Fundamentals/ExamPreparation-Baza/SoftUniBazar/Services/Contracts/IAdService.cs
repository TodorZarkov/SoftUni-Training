namespace SoftUniBazar.Services.Contracts
{
    using Models.Ad;

    public interface IAdService
    {
        Task<ICollection<AllAdViewModel>> AllAsync();

        Task<int> CreateAsync(FormAdViewModel adModel, string userId);

        Task EditAsync(FormAdViewModel adModel, int adId);


        Task<FormAdViewModel> GetForEditByIdAsync(int adId);


        Task<bool> IsOwnerAsync(string userId, int adId);
    }
}
