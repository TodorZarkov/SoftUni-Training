namespace Homies.Services
{
	using Homies.Data;
	using Homies.Models.Event;
	using Homies.Services.Contracts;

	using static Constants.FormatConstants;

	using Microsoft.EntityFrameworkCore;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using System.Collections;
	using System.Xml.Linq;

	public class EventService : IEventService
	{
		private readonly HomiesDbContext dbContext;

		public EventService(HomiesDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<ICollection<AllEventViewModel>> AllAsync()
		{
			var events = await dbContext.Events
				.AsNoTracking()
				.Select(e => new AllEventViewModel
				{
					Id = e.Id,
					Name = e.Name,
					Start = e.Start.ToString(DateTimeFormat),
					Type = e.Type.Name,
					Organiser = e.Organiser.UserName
				})
				.ToArrayAsync();

			return events;
		}

		public async Task<int> CreateAsync(FormEventViewModel model, string userId)
		{
			Data.Event ev = new Event
			{
				CreatedOn = DateTime.Now,
				Description = model.Description,
				End = model.End,
				Name = model.Name,
				OrganiserId = userId,
				Start = model.Start,
				TypeId = model.TypeId
			};

			await dbContext.AddAsync(ev);
			await dbContext.SaveChangesAsync();

			return ev.Id;
		}

		public async Task EditAsync(FormEventViewModel model, int eventId)
		{
			Data.Event ev = await dbContext.Events.FindAsync(eventId) ?? throw new ArgumentNullException("The Event Id doesn't exist.");
			ev.Description = model.Description;
			ev.End = model.End;
			ev.Name = model.Name;
			ev.Start = model.Start;
			ev.TypeId = model.TypeId;

			await dbContext.SaveChangesAsync();
		}

		public async Task<DetailsEventViewModel> GetByIdAsync(int eventId)
		{
			DetailsEventViewModel model = await dbContext.Events
				.AsNoTracking()
				.Where(e => e.Id == eventId)
				.Select(e => new DetailsEventViewModel
				{
					Id = e.Id,
					CreatedOn = e.CreatedOn.ToString(DateTimeFormat),
					Description = e.Description,
					End = e.End.ToString(DateTimeFormat),
					Name = e.Name,
					Organiser = e.Organiser.UserName,
					Start = e.Start.ToString(DateTimeFormat),
					Type = e.Type.Name
				})
				.FirstAsync();

			return model;
		}

		public async Task<FormEventViewModel> GetForEditByIdAsync(int eventId)
		{
			FormEventViewModel model = await dbContext.Events
				.AsNoTracking()
				.Where(e => e.Id == eventId)
				.Select(e => new FormEventViewModel
				{
					Description = e.Description,
					End = e.End,
					Name = e.Name,
					Start = e.Start,
					TypeId = e.TypeId
				})
				.FirstAsync();

			return model;
		}

		public async Task<bool> IsOwnerAsync(string userId, int eventId)
		{
			bool result = await dbContext.Events
				.AsNoTracking()
				.AnyAsync(e => e.Id == eventId && e.OrganiserId == userId);

			return result;
		}
	}
}
