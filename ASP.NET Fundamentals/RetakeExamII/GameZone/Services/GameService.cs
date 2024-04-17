namespace GameZone.Services
{
    using Data;
    using Models.Game;
    using static Constants.FormatConstants;
    using GameZone.Services.Contracts;

    using Microsoft.EntityFrameworkCore;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class GameService : IGameService
    {
        private readonly GameZoneDbContext dbContext;

        public GameService(GameZoneDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<AllGameViewModel>> AllAsync()
        {
            var games = await dbContext.Games
                .AsNoTracking()
                .Select(g => new AllGameViewModel
                {
                    Id = g.Id,
                    Title = g.Title,
                    ReleasedOn = g.ReleasedOn.ToString(DateTimeFormat),
                    Genre = g.Genre.Name,
                    ImageUrl = g.ImageUrl,
                    Publisher = g.Publisher.UserName
                })
                .ToArrayAsync();

            return games;
        }

        public async Task<int> CreateAsync(FormGameViewModel model, string userId)
        {
            Game game = new Game
            {
                Description = model.Description,
                ReleasedOn = model.ReleasedOn,
                Title = model.Title,
                PublisherId = userId,
                GenreId = model.GenreId,
                ImageUrl = model.ImageUrl,
            };

            await dbContext.AddAsync(game);
            await dbContext.SaveChangesAsync();

            return game.Id;
        }

        public async Task Delete(int gameId)
        {
            GamerGame[] gamerGames = await dbContext.GamersGames
                .Where(gg => gg.GameId == gameId)
                .ToArrayAsync();

            dbContext.GamersGames.RemoveRange(gamerGames);

            Game game = await dbContext.Games.FindAsync(gameId) ?? throw new ArgumentNullException("The specified game id doesn't exist.");

            dbContext.Games.Remove(game);

            await dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(FormGameViewModel model, int gameId)
        {
            Game game = await dbContext.Games.FindAsync(gameId) ?? throw new ArgumentNullException("The Game Id doesn't exist.");
            game.Description = model.Description;
            game.ReleasedOn = model.ReleasedOn;
            game.Title = model.Title;
            game.GenreId = model.GenreId;
            game.ImageUrl = model.ImageUrl;

            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(int gameId)
        {
            bool result = await dbContext.Games
                .AnyAsync(g => g.Id == gameId);

            return result;
        }

        public async Task<GameViewModel> GetByIdAsync(int gameId)
        {
            GameViewModel model = await dbContext.Games
                .AsNoTracking()
                .Where(g => g.Id == gameId)
                .Select(g => new GameViewModel
                {
                    Id = g.Id,
					Description = g.Description,
					ReleasedOn = g.ReleasedOn.ToString(DateTimeFormat),
					Title = g.Title,
					Publisher = g.Publisher.UserName,
					Genre = g.Genre.Name,
					ImageUrl = g.ImageUrl
				})
                .FirstAsync();

            return model;
        }

        public async Task<DeleteGameViewModel> GetForDeleteByIdAsync(int gameId)
        {
            DeleteGameViewModel model = await dbContext.Games
               .AsNoTracking()
               .Where(g => g.Id == gameId)
               .Select(g => new DeleteGameViewModel
               {
                   Id = g.Id,
                   Title = g.Title,
                   Publisher = g.Publisher.UserName
               })
               .FirstAsync();

            return model;
        }

        public async Task<FormGameViewModel> GetForEditByIdAsync(int gameId)
        {
            FormGameViewModel model = await dbContext.Games
                .AsNoTracking()
                .Where(g => g.Id == gameId)
                .Select(g => new FormGameViewModel
                {
                    Description = g.Description,
					ReleasedOn = g.ReleasedOn,
					Title = g.Title,
					GenreId = g.GenreId,
					ImageUrl = g.ImageUrl
				})
                .FirstAsync();

            return model;
        }

        public async Task<bool> IsOwnerAsync(string userId, int gameId)
        {
            bool result = await dbContext.Games
                .AsNoTracking()
                .AnyAsync(g => g.Id == gameId && g.PublisherId == userId);

            return result;
        }
    }
}
