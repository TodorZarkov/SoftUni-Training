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

        public async Task<int> Create(MovieFormDTO model)
        {
            Movie movie = new()
            {
                Director = model.Director,
                GenreId = model.GenreId,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                Title = model.Title,
            };

            await dbContext.Movies
                .AddAsync(movie);

            return movie.Id;
        }

        public async Task<ICollection<MovieAllDTO>> GetAll()
        {
            MovieAllDTO[] movies = await dbContext.Movies
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
