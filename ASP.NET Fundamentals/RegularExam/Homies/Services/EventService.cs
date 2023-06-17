namespace Homies.Services
{
    using Homies.Data;
    using Homies.Data.Models;
    using Homies.Models.Event;
    using Homies.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;

    public class EventService : IEventService
    {
        private readonly HomiesDbContext dbContext;

        public EventService(HomiesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Add(string userId, FormEventViewModel viewModel)
        {
            var model = new Event()
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                TypeId = viewModel.TypeId,
                CreatedOn = DateTime.UtcNow,
                OrganiserId = userId,
                Start = DateTime.Parse(viewModel.Start),
                End = DateTime.Parse(viewModel.End)
            };

            await dbContext.AddAsync(model);

            await dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<AllEventViewModel>> GetAllEventsAsync()
        {
            var allEvents = await dbContext.Events
                .Select(e => new AllEventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Type = e.Type.Name,
                    Start = e.Start.ToString("dd-MMM-yyyy H:mm", CultureInfo.InvariantCulture),
                    Organiser = e.Organiser.UserName
                })
                .ToArrayAsync();

            return allEvents;
        }

        public async Task<ICollection<AllEventViewModel>> GetAllEventsAsync(string userId)
        {
            var allEvents = await dbContext.Events
                .AsNoTracking()
                .Where(e => e.EventsParticipants.Any(ep => ep.HelperId == userId))
                .Select(e => new AllEventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Type = e.Type.Name,
                    Start = e.Start.ToString("dd-MMM-yyyy H:mm", CultureInfo.InvariantCulture),
                    Organiser = e.Organiser.UserName
                })
                .ToArrayAsync();

            return allEvents;
        }

        public async Task<EventViewModel> GetAsync(int id)
        {


            var viewModel = await dbContext.Events
                .Where(model => model.Id == id)
                .Select(model => new EventViewModel()
                {
                    Description = model.Description,
                    CreatedOn = model.CreatedOn.ToString("dd-MMM-yyyy H:mm:ss", CultureInfo.InvariantCulture),
                    End = model.End.ToString("dd-MMM-yyyy H:mm", CultureInfo.InvariantCulture),
                    Name = model.Name,
                    Organiser = model.Organiser.UserName,
                    Start = model.Start.ToString("dd-MMM-yyyy H:mm", CultureInfo.InvariantCulture),
                    Type = model.Type.Name
                })
                .FirstAsync();
                

            return viewModel;
        }

        public async Task JoinAsync(string userId, int eventId)
        {
            bool isValidEvent = await dbContext.Events
                .AnyAsync(e => e.Id == eventId);
            bool isAlreadyParticipant = await dbContext.EventsParticipants
                .AnyAsync(ep => ep.HelperId == userId && ep.EventId == eventId);
            if (!isValidEvent || isAlreadyParticipant)
            {
                throw new InvalidOperationException("Event id not present in the db, or user already participant");
            }

            var eventParticipant = new EventParticipant()
            {
                EventId = eventId,
                HelperId = userId
            };

            await dbContext.EventsParticipants.AddAsync(eventParticipant);
            await dbContext.SaveChangesAsync();
        }

        public async Task LeavAsync(string userId, int eventId)
        {
            var eventParticipant = await dbContext.EventsParticipants.FirstAsync(ep => ep.EventId == eventId && ep.HelperId == userId);
            dbContext.EventsParticipants.Remove(eventParticipant);
            await dbContext.SaveChangesAsync();
        }
    }
}
