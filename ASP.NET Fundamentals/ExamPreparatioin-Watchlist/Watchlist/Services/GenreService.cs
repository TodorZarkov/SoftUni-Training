namespace Watchlist.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Watchlist.Data;
    using Watchlist.Models;
    using Watchlist.Services.Contracts;

    public class GenreService : IGenreService
    {
        private readonly WatchlistDbContext dbContext;

        public GenreService(WatchlistDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> ExistById(int genreId)
        {
            var result = await dbContext.Genres
                .FindAsync(genreId);
            if (result == null)
            {
                return false;
            }

            return true;
        }

        public async Task<ICollection<GenreSelectDTO>> GetForSelect()
        {
            GenreSelectDTO[] genres = await dbContext.Genres
                .Select(g => new GenreSelectDTO
                {
                    Id = g.Id,
                    Name = g.Name,
                })
                .ToArrayAsync();

            return genres;
        }
    }
}
