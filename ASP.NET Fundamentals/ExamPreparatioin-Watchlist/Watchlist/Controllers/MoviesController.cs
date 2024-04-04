namespace Watchlist.Controllers
{
    using Watchlist.Services.Contracts;

    using Microsoft.AspNetCore.Mvc;
    using Watchlist.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc.Infrastructure;

    public class MoviesController : BaseController
    {
        private readonly IMovieService movieService;
        private readonly IUserMovieService userMovieService;
        private readonly IGenreService genreService;
        private readonly UserManager<Watchlist.Data.User> userManager;

        public MoviesController(
            IMovieService movieService,
            IUserMovieService userMovieService,
            UserManager<Data.User> userManager,
            IGenreService genreService)
        {
            this.movieService = movieService;
            this.userMovieService = userMovieService;
            this.userManager = userManager;
            this.genreService = genreService;
        }


        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await movieService.GetAllAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            MovieFormDTO model = new MovieFormDTO();
            model.AvailableGenres = await genreService.GetForSelect();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MovieFormDTO model)
        {
            bool genreExist = await genreService.ExistById(model.GenreId);
            if (!genreExist)
            {
                ModelState.AddModelError(nameof(model.GenreId), "Invalid Genre!");
            }
            if (!ModelState.IsValid)
            {
                model.AvailableGenres = await genreService.GetForSelect();
                return View(model);
            }

            int movieId = await movieService.CreateAsync(model);

            return RedirectToAction("All", "Movies");
        }

        [HttpGet]
        public async Task<IActionResult> Watched()
        {
            string userId = userManager.GetUserId(User);
            ICollection<MovieAllDTO> model = await userMovieService.AllAsync(userId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int movieId)
        {
            string userId = userManager.GetUserId(User);
            if (!await userMovieService.Exist(movieId, userId))
            {
                await userMovieService.Add(movieId, userId);
            }
            return RedirectToAction("All", "Movies");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int movieId)
        {
            string userId = userManager.GetUserId(User);

            await userMovieService.Remove(movieId, userId);
            return RedirectToAction("Watched", "Movies");
        }
    }
}
