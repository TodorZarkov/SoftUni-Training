namespace Forum.App.Data.Configuration
{
	using Forum.App.Data.Models;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public class PostEntityConfiguration : IEntityTypeConfiguration<Post>
	{
		public void Configure(EntityTypeBuilder<Post> builder)
		{
			List<Post> posts = new();

			Post currentPost;
		}
	}
}
