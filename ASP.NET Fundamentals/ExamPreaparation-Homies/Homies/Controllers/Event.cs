namespace Homies.Controllers
{
	using Homies.Models.Event;
	using Homies.Services.Contracts;
	using static Constants.ErrorMessages;

	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Identity;

	public class Event : BaseController
	{
		private readonly IEventService eventService;
		private readonly ITypeService typeService;
		private readonly IEventParticipantService eventParticipantService;
		private readonly UserManager<IdentityUser> userManager;

		public Event(IEventService eventService, ITypeService typeService, IEventParticipantService eventParticipantService, UserManager<IdentityUser> userManager)
		{
			this.eventService = eventService;
			this.typeService = typeService;
			this.eventParticipantService = eventParticipantService;
			this.userManager = userManager;
		}


		[HttpGet]
		public async Task<IActionResult> All()
		{
			var model = await eventService.AllAsync();

			return View(model);
		}


		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var model = new FormEventViewModel
			{
				Types = (await typeService.AllAsync()).ToArray()
			};

			return View(model);
		}


		[HttpPost]
		public async Task<IActionResult> Add(FormEventViewModel model)
		{
			if (!ModelState.IsValid)
			{
				model.Types = (await typeService.AllAsync()).ToArray();
				return View(model);
			}
			bool isValidTypeId = await typeService.ExistAsync(model.TypeId);
			if (!isValidTypeId)
			{
				ModelState.AddModelError(nameof(model.TypeId), InvalidTypeId);
				model.Types = (await typeService.AllAsync()).ToArray();
				return View(model);
			}

			if (model.Start >= model.End)
			{
				ModelState.AddModelError(nameof(model.End), InvalidEndDate);
				model.Types = (await typeService.AllAsync()).ToArray();
				return View(model);
			}

			int eventId = await eventService.CreateAsync(model, userManager.GetUserId(User));

			return RedirectToAction("All", "Event");
		}


		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			string userId = userManager.GetUserId(User);
			bool canEdit = await eventService.IsOwnerAsync(userId, id);
			if (!canEdit)
			{
				return RedirectToAction("All", "Event");
			}

			FormEventViewModel model = await eventService.GetForEditByIdAsync(id);
			model.Types = (await typeService.AllAsync()).ToArray();
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(FormEventViewModel model, int id)
		{
			string userId = userManager.GetUserId(User);
			bool canEdit = await eventService.IsOwnerAsync(userId, id);
			if (!canEdit)
			{
				return RedirectToAction("All", "Event");
			}

			if (!ModelState.IsValid)
			{
				model.Types = (await typeService.AllAsync()).ToArray();
				return View(model);
			}
			bool isValidTypeId = await typeService.ExistAsync(model.TypeId);
			if (!isValidTypeId)
			{
				ModelState.AddModelError(nameof(model.TypeId), InvalidTypeId);
				model.Types = (await typeService.AllAsync()).ToArray();
				return View(model);
			}

			if (model.Start >= model.End)
			{
				ModelState.AddModelError(nameof(model.End), InvalidEndDate);
				model.Types = (await typeService.AllAsync()).ToArray();
				return View(model);
			}


			await eventService.EditAsync(model, id);

			return RedirectToAction("All", "Event");

		}

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			var model = await eventService.GetByIdAsync(id);

			return View(model);
		}


		[HttpGet]
		public async Task<IActionResult> Joined()
		{
			string userId = userManager.GetUserId(User);
			var model = await eventParticipantService.AllByUser(userId);

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Join(int id)
		{
			string userId = userManager.GetUserId(User);

			bool isOwner = await eventService.IsOwnerAsync(userId, id);
			if (isOwner)
			{
				return RedirectToAction("Joined", "Event");

			}

			bool exist = await eventParticipantService.ExistAsync(userId, id);
			if (exist)
			{
				return RedirectToAction("All", "Event");
			}

			await eventParticipantService.Add(userId, id);

			return RedirectToAction("Joined", "Event");
		}

		[HttpPost]
		public async Task<IActionResult> Leave(int id)
		{
			string userId = userManager.GetUserId(User);

			bool isOwner = await eventService.IsOwnerAsync(userId, id);
			if (isOwner)
			{
				return RedirectToAction("All", "Event");

			}

			

			await eventParticipantService.Remove(userId, id);

			return RedirectToAction("All", "Event");
		}
	}
}
