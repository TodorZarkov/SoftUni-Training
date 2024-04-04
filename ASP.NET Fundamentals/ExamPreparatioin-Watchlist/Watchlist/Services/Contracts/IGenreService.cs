namespace Watchlist.Services.Contracts
{
    using Watchlist.Models;

    public interface IGenreService
    {
        Task<ICollection<GenreSelectDTO>> GetForSelect();

        Task<bool> ExistById(int genreId);
    }
}
