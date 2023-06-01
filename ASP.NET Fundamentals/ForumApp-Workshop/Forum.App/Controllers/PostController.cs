namespace Forum.App.Controllers
{
	using Forum.Services.Interfaces;
	using Forum.ViewModels.Post;
	using Microsoft.AspNetCore.Mvc;

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
	}
}
