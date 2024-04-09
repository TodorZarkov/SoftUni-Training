namespace Homies.Services.Contracts
{
	using Homies.Models.Event;

	public interface IEventService
	{
		Task<ICollection<AllEventViewModel>> AllAsync();

		Task<int> CreateAsync(FormEventViewModel eventModel, string userId);

		Task EditAsync(FormEventViewModel eventModel, string eventId);

		Task<DetailsEventViewModel> GetByIdAsync(int eventId);


		Task<bool> IsOwnerAsync(string userId, int eventId);
	}
}
