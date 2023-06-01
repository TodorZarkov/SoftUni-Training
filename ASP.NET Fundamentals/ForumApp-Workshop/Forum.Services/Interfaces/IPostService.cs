namespace Forum.Services.Interfaces
{
	using Forum.ViewModels.Post;

	public interface IPostService
	{
		Task<IEnumerable<PostListViewModel>> ListAllAsync();
	}
}
