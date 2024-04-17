namespace GameZone.Controllers
{
    using GameZone.Models.Game;
    using GameZone.Services.Contracts;
    using static Constants.ErrorMessages;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class GameController : BaseController
    {
        private readonly IGameService gameService;
        private readonly IGenreService genreService;
        private readonly IGamerGameService gamerGameService;
        private readonly UserManager<IdentityUser> userManager;

        public GameController(IGameService gameService, IGenreService genreService, IGamerGameService gamerGameService, UserManager<IdentityUser> userManager)
        {
            this.gameService = gameService;
            this.genreService = genreService;
            this.gamerGameService = gamerGameService;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await gameService.AllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new FormGameViewModel
            {
                Genres = (await genreService.AllAsync()).ToArray()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(FormGameViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Genres = (await genreService.AllAsync()).ToArray();
                return View(model);
            }
            bool isValidGenreId = await genreService.ExistAsync(model.GenreId);
            if (!isValidGenreId)
            {
                ModelState.AddModelError(nameof(model.GenreId), InvalidGenreId);
                model.Genres = (await genreService.AllAsync()).ToArray();
                return View(model);
            }



            int gameId = await gameService.CreateAsync(model, userManager.GetUserId(User));

            return RedirectToAction("All", "Game");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            string userId = userManager.GetUserId(User);
            bool canEdit = await gameService.IsOwnerAsync(userId, id);
            if (!canEdit)
            {
                return RedirectToAction("All", "Game");
            }

            FormGameViewModel model = await gameService.GetForEditByIdAsync(id);
            model.Genres = (await genreService.AllAsync()).ToArray();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FormGameViewModel model, int id)
        {
            string userId = userManager.GetUserId(User);
            bool canEdit = await gameService.IsOwnerAsync(userId, id);
            if (!canEdit)
            {
                return RedirectToAction("All", "Game");
            }

            if (!ModelState.IsValid)
            {
                model.Genres = (await genreService.AllAsync()).ToArray();
                return View(model);
            }
            bool isValidGenreId = await genreService.ExistAsync(model.GenreId);
            if (!isValidGenreId)
            {
                ModelState.AddModelError(nameof(model.GenreId), InvalidGenreId);
                model.Genres = (await genreService.AllAsync()).ToArray();
                return View(model);
            }



            await gameService.EditAsync(model, id);

            return RedirectToAction("All", "Game");

        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await gameService.GetByIdAsync(id);

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> MyZone()
        {
            string userId = userManager.GetUserId(User);
            var model = await gamerGameService.AllByUserAsync(userId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddToMyZone(int id)
        {
            string userId = userManager.GetUserId(User);
            bool existGame = await gameService.ExistAsync(id);
            if (!existGame)
            {
                return RedirectToAction("All", "Game");
            }
          
            bool existInCollection = await gamerGameService.ExistAsync(userId, id);
            if (existInCollection)
            {
                return RedirectToAction("All", "Game");
            }

            await gamerGameService.AddAsync(userId, id);

            return RedirectToAction("MyZone", "Game");
        }

        [HttpGet]
        public async Task<IActionResult> StrikeOut(int id)
        {
            string userId = userManager.GetUserId(User);
            bool existGame = await gameService.ExistAsync(id);
            if (!existGame)
            {
                return RedirectToAction("All", "Game");
            }

           
            await gamerGameService.RemoveAsync(userId, id);

            return RedirectToAction("MyZone", "Game");
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            string userId = userManager.GetUserId(User);
            bool existGame = await gameService.ExistAsync(id);
            bool canDelete = await gameService.IsOwnerAsync(userId, id);
            if (!existGame || !canDelete)
            {
                return RedirectToAction("All", "Game");
            }

            DeleteGameViewModel model = await gameService.GetForDeleteByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(DeleteGameViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("All", "Game");
            }
            string userId = userManager.GetUserId(User);
            bool existGame = await gameService.ExistAsync(model.Id);
            bool canDelete = await gameService.IsOwnerAsync(userId, model.Id);
            if (!existGame || !canDelete)
            {
                return RedirectToAction("All", "Game");
            }

            await gameService.Delete(model.Id);

            return RedirectToAction("All", "Game");
        }
    }
}
