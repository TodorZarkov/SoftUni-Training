namespace Watchlist.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Watchlist.Data;

    [Authorize]
    public abstract class BaseController : Controller
    {
        //private readonly SignInManager<Watchlist.Data.User> signInManager;
        //private readonly UserManager<Watchlist.Data.User> userManager;
        //public BaseController(SignInManager<User> signInManager, UserManager<User> userManager)
        //{
        //    this.signInManager = signInManager;
        //    this.userManager = userManager;
        //}
    }
}
