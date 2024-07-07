namespace GameZone.Services
{
    using GameZone.Services.Contracts;
    using Data;
    using Models.Genre;

    using Microsoft.EntityFrameworkCore;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class GenreService : IGenreService
    {
        private readonly GameZoneDbContext dbContext;

        public GenreService(GameZoneDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<GenreViewModel>> AllAsync()
        {
            var genres = await dbContext.Genres
                .AsNoTracking()
                .Select(g => new GenreViewModel
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToArrayAsync();

            return genres;
        }

        public async Task<bool> ExistAsync(int genreId)
        {
            Genre? genre = await dbContext.Genres.FindAsync(genreId);

            if (genre == null)
            {
                return false;
            }

            return true;
        }
    }
}
