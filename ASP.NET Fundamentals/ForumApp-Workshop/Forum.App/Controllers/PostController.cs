namespace Forum.App.Controllers
{
	using Forum.Services.Interfaces;
	using Forum.ViewModels.Post;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

	public class PostController : Controller
	{
		private readonly IPostService postService;

		public PostController(IPostService postService)
		{
			this.postService = postService;
		}

		public async Task<IActionResult> All()
		{
			IEnumerable<PostListViewModel> allPosts =
				await postService.ListAllAsync();

			return View(allPosts);
		}

		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(PostAddFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			try
			{
				await postService.AddPostAsync(model);
			}
			catch (Exception error)
			{
				ModelState.AddModelError(string.Empty, $"Unexpected error occured: {error.Message}");
				return View(model);
			}

			return RedirectToAction(nameof(All));
		}


		[HttpGet]
		public async Task<IActionResult> Edit(string id)
		{
			PostAddFormModel? model = await postService.GetPost(Guid.Parse(id));

			if (model == null)
			{
				return RedirectToAction(nameof(All));
			}

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(string id, PostAddFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			try
			{
				await postService.EditPostAsync(id, model);
			}
			catch (Exception error)
			{
				ModelState.AddModelError(string.Empty, $"Unexpected error occured: {error.Message}");
				return View(model);
			}


			return RedirectToAction(nameof(All));
		}

		[HttpPost]
		public async Task<IActionResult> Delete(string id)
		{
			try
			{
				await postService.Delete(id);
			}
			catch (Exception)
			{
			}
			
			return RedirectToAction(nameof(All));

		}
	}

}
