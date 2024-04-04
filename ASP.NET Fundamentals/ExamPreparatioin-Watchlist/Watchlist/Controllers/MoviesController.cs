namespace Watchlist.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class MoviesController : BaseController
    {
       

        public async Task<IActionResult> All()
        {

            return View();
        }
    }
}
