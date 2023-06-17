namespace Homies.Controllers
{
    using Homies.Extensions;
    using Homies.Models.Event;
    using Homies.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using static Homies.Common.Validators;

    public class EventController : BaseController
    {
        private readonly IEventService eventService;
        private readonly ITypeService typeService;

        public EventController(IEventService eventService, ITypeService typeService)
        {
            this.eventService = eventService;
            this.typeService = typeService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var allEvents = await eventService.GetAllEventsAsync();

            return View(allEvents);
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var allTypes = await typeService.GetAllTypesForSelectAsync();
            var eventViewModel = new FormEventViewModel();
            eventViewModel.Types = allTypes;

            return View(eventViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(FormEventViewModel viewModel)
        {
            if (!(await typeService.IsValidType(viewModel.TypeId)))
            {
                var allTypes = await typeService.GetAllTypesForSelectAsync();
                viewModel.Types = allTypes;

                ModelState.AddModelError(nameof(viewModel.Types), "Invalid Type");
                return View(viewModel);
            }

            if (!IsSecondAfterFirst(viewModel.Start, viewModel.End))
            {
                var allTypes = await typeService.GetAllTypesForSelectAsync();
                viewModel.Types = allTypes;

                ModelState.AddModelError(nameof(viewModel.End), "The start date must proceed the edn date. Format must be yyyy-MM-dd H:mm");
                return View(viewModel);
            }

            if (!ModelState.IsValid)
            {
                var allTypes = await typeService.GetAllTypesForSelectAsync();
                viewModel.Types = allTypes;

                return View(viewModel);
            }


            string userId = User.GetId();

            try
            {
                await eventService.Add(userId, viewModel);
                return RedirectToAction("All", "Event");
            }
            catch (Exception)
            {
                return RedirectToAction("All", "Event");
            }


        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            var allEvents = await eventService.GetAllEventsAsync(User.GetId());

            return View(allEvents);
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            string userId = User.GetId();

            try
            {
                await eventService.JoinAsync(userId, id);
                return RedirectToAction("Joined", "Event");
            }
            catch (Exception)
            {
                return RedirectToAction("Joined", "Event");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            string userId = User.GetId();

            try
            {
                await eventService.LeavAsync(userId, id);
                return RedirectToAction("Joined", "Event");
            }
            catch (Exception)
            {
                return RedirectToAction("Joined", "Event");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Details(int id)
        {

        }
    }
}
