namespace Homies.Services.Contracts
{
	using Homies.Models.Event;

	public interface IEventParticipantService
	{
		Task AddAsync(string userId, int eventId);

		Task RemoveAsync(string userId, int eventId);

		Task<bool> ExistAsync(string userId, int eventId);


		Task<ICollection<AllEventViewModel>> AllByUserAsync(string userId);
	}
}
