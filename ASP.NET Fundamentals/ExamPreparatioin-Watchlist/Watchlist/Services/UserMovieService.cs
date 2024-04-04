namespace Watchlist.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Watchlist.Data;
    using Watchlist.Models;
    using Watchlist.Services.Contracts;

    public class UserMovieService : IUserMovieService
    {
        private readonly WatchlistDbContext dbContext;

        public UserMovieService(WatchlistDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        public async Task Add(int movieId, string userId)
        {
            UserMovie um = new()
            {
                UserId = userId,
                MovieId = movieId,
            };

            await dbContext.AddAsync(um);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<MovieAllDTO>> AllAsync(string userId)
        {
            MovieAllDTO[] watched = await dbContext.UsersMovies
                .Where(um => um.UserId == userId)
                .Select(um => new MovieAllDTO
                {
                    Title = um.Movie.Title,
                    Director = um.Movie.Director,
                    Genre = um.Movie.Genre.Name,
                    Id = um.MovieId,
                    ImageUrl = um.Movie.ImageUrl,
                    Rating = um.Movie.Rating.ToString("#,00"),
                })
                .ToArrayAsync();

            return watched;
        }

        public async Task<bool> Exist(int movieId, string userId)
        {
            var result = await dbContext.UsersMovies
                .FindAsync(userId, movieId);

            if (result == null)
            {
                return false;
            }

            return true;
        }

        public async Task Remove(int movieId, string userId)
        {
            var result = await dbContext.UsersMovies
               .FindAsync(userId, movieId);
            if (result == null)
            {
                return;
            }

            dbContext.Remove(result);

            await dbContext.SaveChangesAsync();
        }
    }
}
