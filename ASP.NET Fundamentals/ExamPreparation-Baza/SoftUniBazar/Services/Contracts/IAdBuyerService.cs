namespace SoftUniBazar.Services.Contracts
{
	using SoftUniBazar.Models.Ad;

	public interface IAdBuyerService
    {
        Task AddAsync(string userId, int adId);

        Task RemoveAsync(string userId, int adId);

        Task<bool> ExistAsync(string userId, int adId);


        Task<ICollection<AllAdViewModel>> AllByUserAsync(string userId);
    }
}
