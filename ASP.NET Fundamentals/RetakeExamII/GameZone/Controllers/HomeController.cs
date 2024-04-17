using GameZone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GameZone.Controllers
{
    public class HomeController : BaseController
    {
		private readonly SignInManager<IdentityUser> signInManager;

		public HomeController(SignInManager<IdentityUser> signInManager)
		{
			this.signInManager = signInManager;
		}



		[AllowAnonymous]
        public IActionResult Index()
        {
			if (signInManager.IsSignedIn(User))
			{
				return RedirectToAction("All", "Game");
			}
			return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
