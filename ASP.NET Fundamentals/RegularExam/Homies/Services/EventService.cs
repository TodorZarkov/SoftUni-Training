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
    using static Homies.Common.EntityValidationConstants.Date;

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

        public async Task EditAsync(int eventId, FormEventViewModel viewModel)
        {
            var model = await dbContext.Events.FirstAsync(e => e.Id == eventId);

            model.Name = viewModel.Name;
            model.Description = viewModel.Description;
            model.Start = DateTime.Parse(viewModel.Start);
            model.End = DateTime.Parse(viewModel.End);
            model.TypeId = viewModel.TypeId;

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
                    Start = e.Start.ToString(MainDateFormat, CultureInfo.InvariantCulture),
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
                    Start = e.Start.ToString(MainDateFormat, CultureInfo.InvariantCulture),
                    Organiser = e.Organiser.UserName
                })
                .ToArrayAsync();

            return allEvents;
        }

        public async Task<EventViewModel> GetAsync(int eventId)
        {


            var viewModel = await dbContext.Events
                .Where(model => model.Id == eventId)
                .Select(model => new EventViewModel()
                {
                    Id = model.Id,
                    Description = model.Description,
                    CreatedOn = model.CreatedOn.ToString(MainDateFormat, CultureInfo.InvariantCulture),
                    End = model.End.ToString(MainDateFormat, CultureInfo.InvariantCulture),
                    Name = model.Name,
                    Organiser = model.Organiser.UserName,
                    Start = model.Start.ToString(MainDateFormat, CultureInfo.InvariantCulture),
                    Type = model.Type.Name
                })
                .FirstAsync();
                

            return viewModel;
        }

        public async Task<FormEventViewModel> GetForEditAsync(int eventId)
        {
            var model = await dbContext.Events.FirstAsync(e => e.Id == eventId);

            var viewModel = new FormEventViewModel()
            {
                Name = model.Name,
                Description = model.Description,
                Start = model.Start.ToString(MainDateFormat),
                End = model.End.ToString(MainDateFormat),
                TypeId = model.TypeId,
            };

            return viewModel;
        }

        public async Task<bool> IsOwner(string userId, int eventId)
        {
            var e = await dbContext.Events.FindAsync(eventId);
            if (e != null)
            {
                return e.OrganiserId == userId;
            }

            return false;
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
