namespace Forum.Data.Seeding
{
	using Forum.Data.Models;

	internal class PostSeeder
	{
		internal ICollection<Post> GeneratePosts()
		{
			HashSet<Post> posts = new();

			Post currentPost;

			currentPost = new Post
			{
				Title = "My first Post",
				Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s"
			};
			posts.Add(currentPost);

			currentPost = new Post
			{
				Title = "My second Post",
				Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy"
			};
			posts.Add(currentPost);

			currentPost = new Post
			{
				Title = "My third Post",
				Content = "Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy"
			};
			posts.Add(currentPost);


			return posts;
		}
	}
}
