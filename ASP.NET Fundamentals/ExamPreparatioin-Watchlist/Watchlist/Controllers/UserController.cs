namespace Watchlist.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Watchlist.Data;
    using Watchlist.Models;

    public class UserController : BaseController
    {
        private readonly UserManager<Watchlist.Data.User> userManager;
        private readonly SignInManager<Watchlist.Data.User> signInManager;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }



        [AllowAnonymous]
        [HttpGet]
        public IActionResult  Register()
        {
            RegisterDTO model = new RegisterDTO();

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Watchlist.Data.User user = new()
            {
                UserName = model.UserName,
                Email = model.Email,
            };

            IdentityResult result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }

            //await signInManager.SignInAsync(user, isPersistent: false);

            return RedirectToAction("Login", "User");
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            LoginDTO model = new();

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: false, lockoutOnFailure: true);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status405MethodNotAllowed);
            }

            return RedirectToAction("All", "Movies");
        }


        [HttpPost]
        public async Task<IActionResult> Logout(string id)
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
