namespace SoftUniBazar.Services.Interfaces
{
    using SoftUniBazar.Models.Ad;

    public interface IAdService
    {
        Task<ICollection<AdAllViewModel>> AllAsync();


        Task AddAsync(AdFormModel adFormModel, string userId);
		Task<AdFormModel> GetByIdAsync(int id);
		Task<bool> UserAuthorizedAsync(string userId, int id);
		Task UpdateAsync(AdFormModel model, int id);
		Task<bool> IsInCartAsync(int id ,  string userId);
		Task AddToCartAsync(int id, string userId);
	}
}
