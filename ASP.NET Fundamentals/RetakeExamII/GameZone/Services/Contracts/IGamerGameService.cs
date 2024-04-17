namespace GameZone.Services.Contracts
{
    using Models.Game;

    public interface IGamerGameService
    {
        Task AddAsync(string userId, int gameId);

        Task RemoveAsync(string userId, int gameId);

        Task<bool> ExistAsync(string userId, int gameId);


        Task<ICollection<AllGameViewModel>> AllByUserAsync(string userId);
    }
}
