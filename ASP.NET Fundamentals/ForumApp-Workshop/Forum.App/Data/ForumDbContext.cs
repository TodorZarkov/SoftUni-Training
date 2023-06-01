namespace Forum.App.Data
{
	using Forum.App.Data.Models;
	using Microsoft.EntityFrameworkCore;

	public class ForumDbContext : DbContext
	{
		public ForumDbContext(DbContextOptions<ForumDbContext> options) 
			: base(options)
		{
		}

		public DbSet<Post> Posts { get; set; } = null!;
	}
}
