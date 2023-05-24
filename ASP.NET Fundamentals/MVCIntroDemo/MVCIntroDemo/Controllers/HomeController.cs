namespace MVCIntroDemo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MVCIntroDemo.ViewModels;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Msg = "Hello from ViewBag!";
            ViewData["Message"] = "Hello from ViewData!";
            ViewData["People"] = new string[] { "Pesho", "Gosho", "Stamat" };

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "This is asp.net core mvc app.";

            return View();
        }

        public IActionResult Numbers()
        {

            return View();
        }


        [HttpGet]
        public IActionResult NumbersToN()
        {
            ViewBag.Count = -1;
            return View();
        }

        [HttpPost]
		public IActionResult NumbersToN(int count = -1)
		{
			ViewBag.Count = count;
			return View();
		}



		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}