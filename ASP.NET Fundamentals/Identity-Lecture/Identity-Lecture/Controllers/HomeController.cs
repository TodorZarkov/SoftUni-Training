namespace Identity_Lecture.Controllers
{
	using Identity_Lecture.Models;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using System.Diagnostics;

	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly RoleManager<IdentityRole> roleManager;
		private readonly UserManager<IdentityUser> userManager;
		public HomeController(
			ILogger<HomeController> logger,
			RoleManager<IdentityRole> roleManager,
			UserManager<IdentityUser> userManager)
		{
			_logger = logger;
			this.roleManager = roleManager;
			this.userManager = userManager;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> Privacy()
		{
			await roleManager.CreateAsync(new IdentityRole("Admin"));
			var user = await userManager.FindByEmailAsync("haralampi@abv.bg");
			await userManager.AddToRoleAsync(user, "Admin");

			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}