namespace Watchlist.Services.Contracts
{
    using Watchlist.Models;

    public interface IMovieService
    {
        Task<ICollection<MovieAllDTO>> GetAllAsync();

        Task<int> CreateAsync(MovieFormDTO movieModel);

       
    }
}
