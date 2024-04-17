namespace GameZone.Services
{
    using Data;
    using Models.Game;
    using static Constants.FormatConstants;

    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using GameZone.Services.Contracts;

    public class GamerGameService : IGamerGameService
    {
        private readonly GameZoneDbContext dbContext;

        public GamerGameService(GameZoneDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(string userId, int gameId)
        {
            GamerGame gg = new GamerGame
            {
                GameId = gameId,
                GamerId = userId,
            };

            await dbContext.AddAsync(gg);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<AllGameViewModel>> AllByUserAsync(string userId)
        {
            var games = await dbContext.GamersGames
                .AsNoTracking()
                .Where(gg => gg.GamerId == userId)
                .Select(gg => new AllGameViewModel
                {
                    Id = gg.Game.Id,
                    Title = gg.Game.Title,
                    ReleasedOn = gg.Game.ReleasedOn.ToString(DateTimeFormat),
                    Genre = gg.Game.Genre.Name,
                    ImageUrl = gg.Game.ImageUrl,
                    Publisher = gg.Game.Publisher.UserName
                })
                .ToArrayAsync();

            return games;
        }

        public async Task<bool> ExistAsync(string userId, int gameId)
        {
            GamerGame? gg = await dbContext.GamersGames.FindAsync(userId, gameId);

            if (gg == null)
            {
                return false;
            }

            return true;
        }

        public async Task RemoveAsync(string userId, int gameId)
        {
            GamerGame? gg = await dbContext.GamersGames.FindAsync(userId, gameId);

            if (gg == null)
            {
                return;
            }

            dbContext.Remove(gg);
            await dbContext.SaveChangesAsync();
        }


    }
}
