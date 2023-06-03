namespace Forum.Services.Interfaces
{
	using Forum.ViewModels.Post;

	public interface IPostService
	{
		Task<IEnumerable<PostListViewModel>> ListAllAsync();

		Task AddPostAsync(PostAddFormModel model);

		Task<PostAddFormModel?> GetPost(Guid id);

		Task EditPostAsync(string postId, PostAddFormModel model);
		Task Delete(string id);
	}
}
