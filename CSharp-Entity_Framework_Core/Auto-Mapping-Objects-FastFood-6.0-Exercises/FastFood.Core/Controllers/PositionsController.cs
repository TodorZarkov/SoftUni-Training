namespace FastFood.Core.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;

    using ViewModels.Positions;
    using FastFood.Services.Data;

    public class PositionsController : Controller
    {
        private readonly IPositionsService positionsService;

        public PositionsController(IPositionsService positionsService)
        {
            this.positionsService = positionsService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePositionInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            await positionsService.CreateAsync(model);

            return RedirectToAction("All", "Positions");
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<PositionsAllViewModel> positions =
                await positionsService.GetAllAsync();

            return View(positions.ToList());
        }
    }
}
