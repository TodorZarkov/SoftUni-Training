namespace TextSplitter.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using TextSplitter.ViewModels;

	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index(TextSplitViewModel viewModel)
		{
			return View(viewModel);
		}

		[HttpPost]
		public IActionResult Split(TextSplitViewModel viewModel)
		{
			if (!ModelState.IsValid)
			{
				return RedirectToAction("Index", new TextSplitViewModel()
				{
					SplitText = string.Empty,
					TextToSplit = string.Empty
				});
			}

			string[] words = viewModel.TextToSplit
				.Split(" ", StringSplitOptions.RemoveEmptyEntries)
				.ToArray();
			string splitText = string.Join(Environment.NewLine, words);

			viewModel.SplitText = splitText;

			return RedirectToAction("Index", viewModel);
		}

	}
}