namespace Watchlist.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Watchlist.Models;

    public class UserController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult>  Register()
        {
            UserDTO userModel = new UserDTO();

            return View(userModel);
        }
    }
}
