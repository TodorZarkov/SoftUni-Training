namespace Watchlist.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Watchlist.Data;
    using Watchlist.Models;
    using Watchlist.Services.Contracts;

    public class MovieService : IMovieService
    {
        private readonly WatchlistDbContext dbContext;

        public MovieService(WatchlistDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> CreateAsync(MovieFormDTO model)
        {
            Movie movie = new()
            {
                Director = model.Director,
                GenreId = model.GenreId,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                Title = model.Title,
            };

            await dbContext.Movies.AddAsync(movie);
            await dbContext.SaveChangesAsync();

            return movie.Id;
        }

        public async Task<ICollection<MovieAllDTO>> GetAllAsync()
        {
            MovieAllDTO[] movies = await dbContext.Movies
                .AsNoTracking()
                .Select(m => new MovieAllDTO
                {
                    Id = m.Id,
                    Title = m.Title,
                    ImageUrl = m.ImageUrl,
                    Director = m.Director,
                    Genre = m.Genre.Name,
                    Rating = m.Rating.ToString("#.00"),
                })
                .ToArrayAsync();

            return movies;
        }
    }
}
