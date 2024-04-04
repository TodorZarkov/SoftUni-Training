namespace Watchlist.Services.Contracts
{
    public interface IUserMovieService
    {
        Task Add(int movieId, string userId);

        Task Remove(int movieId, string userId);

        Task<bool> Exist(int movieId, string userId);
    }
}
