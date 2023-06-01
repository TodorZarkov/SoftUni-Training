namespace Forum.App.Data.Configuration
{
	using Forum.App.Data.Models;
	using Forum.App.Data.Seeding;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public class PostEntityConfiguration : IEntityTypeConfiguration<Post>
	{
		private readonly PostSeeder postSeeder;

		public PostEntityConfiguration()
		{
			postSeeder = new PostSeeder();
		}
		public void Configure(EntityTypeBuilder<Post> builder)
		{
			builder.HasData(postSeeder.GeneratePosts());
		}
	}
}
