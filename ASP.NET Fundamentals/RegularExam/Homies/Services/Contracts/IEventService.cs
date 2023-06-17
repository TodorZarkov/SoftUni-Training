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

        Task EditAsync(int eventId, FormEventViewModel model);

        Task<FormEventViewModel> GetForEditAsync(int eventId);

        Task<bool> IsOwner(string userId, int eventId);
    }
}
