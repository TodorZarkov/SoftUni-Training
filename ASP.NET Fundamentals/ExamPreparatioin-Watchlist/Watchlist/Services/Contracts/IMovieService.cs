namespace Watchlist.Services.Contracts
{
    using Watchlist.Models;

    public interface IMovieService
    {
        Task<ICollection<MovieAllDTO>> GetAll();

        Task<int> Create(MovieFormDTO movieModel);

       
    }
}
