namespace Watchlist.Services.Contracts
{
    using System.Collections.Generic;
    using Watchlist.Models;

    public interface IUserMovieService
    {
        Task Add(int movieId, string userId);

        Task Remove(int movieId, string userId);

        Task<bool> Exist(int movieId, string userId);

        Task<ICollection<MovieAllDTO>> AllAsync(string userId);
    }
}
