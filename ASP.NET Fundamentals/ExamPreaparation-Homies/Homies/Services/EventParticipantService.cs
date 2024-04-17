namespace Homies.Services
{
	using Homies.Data;
	using Homies.Models.Event;
	using Homies.Services.Contracts;
	using static Constants.FormatConstants;

	using Microsoft.EntityFrameworkCore;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public class EventParticipantService : IEventParticipantService
	{
		private readonly HomiesDbContext dbContext;

		public EventParticipantService(HomiesDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task AddAsync(string userId, int eventId)
		{
			EventParticipant ep = new EventParticipant
			{
				EventId = eventId,
				HelperId = userId,
			};

			await dbContext.AddAsync(ep);
			await dbContext.SaveChangesAsync();
		}

		public async Task<ICollection<AllEventViewModel>> AllByUserAsync(string userId)
		{
			var events = await dbContext.EventsParticipants
				.AsNoTracking()
				.Where(ep => ep.HelperId == userId)
				.Select(ep => new AllEventViewModel
				{
					Id = ep.Event.Id,
					Name = ep.Event.Name,
					Start = ep.Event.Start.ToString(DateTimeFormat),
					Type = ep.Event.Type.Name
				})
				.ToArrayAsync();

			return events;
		}

		public async Task<bool> ExistAsync(string userId, int eventId)
		{
			EventParticipant? ep = await dbContext.EventsParticipants.FindAsync(userId, eventId);

			if (ep == null)
			{
				return false;
			}

			return true;
		}

		public async Task RemoveAsync(string userId, int eventId)
		{
			EventParticipant? ep = await dbContext.EventsParticipants.FindAsync(userId, eventId);

			if (ep == null)
			{
				return;
			}

			dbContext.Remove(ep);
			await dbContext.SaveChangesAsync();
		}


	}
}
