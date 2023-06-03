namespace Forum.Services
{
	using Forum.Data;
	using Forum.Data.Models;
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

		public async Task AddPostAsync(PostAddFormModel model)
		{
			Post post = new()
			{
				Title = model.Title,
				Content = model.Content
			};

			await dbContext.Posts.AddAsync(post);

			await dbContext.SaveChangesAsync();
		}

		public async Task Delete(string id)
		{
			Post post = await dbContext.Posts.FindAsync(Guid.Parse(id));

			dbContext.Posts.Remove(post);

			await dbContext.SaveChangesAsync();
		}

		public async Task EditPostAsync(string postId, PostAddFormModel model)
		{
			Post? post = await dbContext.Posts.FindAsync(Guid.Parse(postId));
			if (post == null)
			{
				throw new ArgumentException("Bad Post Id");
			}

			post.Title = model.Title;
			post.Content = model.Content;

			await dbContext.SaveChangesAsync();
		}

		public async Task<PostAddFormModel?> GetPost(Guid id)
		{
			Post? post = await dbContext.Posts.FindAsync(id);
			if (post == null)
			{
				return null;
			}

			PostAddFormModel model = new()
			{
				//Id = post.Id.ToString(),
				Title = post.Title,
				Content = post.Content
			};

			return model;
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
