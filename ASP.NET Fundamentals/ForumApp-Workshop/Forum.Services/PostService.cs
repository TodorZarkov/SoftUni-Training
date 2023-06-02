namespace Forum.Services
{
	using Forum.Data;
	using Forum.Services.Interfaces;
	using Forum.ViewModels.Post; 

	using Microsoft.EntityFrameworkCore;

	using System.Collections.Generic;
	using System.Threading.Tasks;

	public class PostService : IPostService
	{
		private readonly ForumDbContext dbContext;

		public PostService(ForumDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public async Task<IEnumerable<PostListViewModel>> ListAllAsync()
		{
			IEnumerable<PostListViewModel> allPosts = await dbContext
				.Posts
				.Select(p => new PostListViewModel()
				{
					Id = p.Id.ToString(),
					Title = p.Title,
					Content = p.Content
				})
				.ToArrayAsync();

			return allPosts;
		}
	}
}
