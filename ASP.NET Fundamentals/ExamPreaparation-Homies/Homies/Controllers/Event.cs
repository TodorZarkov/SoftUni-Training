namespace Homies.Controllers
{
	using Homies.Services.Contracts;
	using Microsoft.AspNetCore.Mvc;
	using System.CodeDom.Compiler;

	public class Event : BaseController
	{
		private readonly IEventService eventService;
		private readonly ITypeService typeService;
		private readonly IEventParticipantService eventParticipantService;

		public Event(IEventService eventService, ITypeService typeService, IEventParticipantService eventParticipantService)
		{
			this.eventService = eventService;
			this.typeService = typeService;
			this.eventParticipantService = eventParticipantService;
		}


		[HttpGet]
		public async Task<IActionResult> All()
		{
			var model = await eventService.AllAsync();

			return View(model);
		}
	}
}
