namespace Homies.Services.Contracts
{
    using Homies.Models.Event;

    public interface IEventService
    {
        Task<ICollection<AllEventViewModel>> GetAllEventsAsync();

        Task<ICollection<AllEventViewModel>> GetAllEventsAsync(string userId);

        Task Add(string userId, FormEventViewModel viewModel);

        Task JoinAsync(string userId, int eventId);

        Task LeavAsync(string userId, int eventId);

        Task<EventViewModel> GetAsync(int id);
    }
}
