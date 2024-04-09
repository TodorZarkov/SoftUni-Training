namespace Homies.Services.Contracts
{
	using Homies.Models.Event;

	public interface IEventParticipantService
	{
		Task Add(string userId, int eventId);

		Task Remove(string userId, int eventId);

		Task<bool> ExistAsync(string userId, int eventId);


		Task<ICollection<AllEventViewModel>> AllByUser(string userId);
	}
}
