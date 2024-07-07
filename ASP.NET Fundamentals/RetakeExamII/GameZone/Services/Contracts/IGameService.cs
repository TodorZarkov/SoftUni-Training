namespace GameZone.Services.Contracts
{
    using Models.Game;

    public interface IGameService
    {
        Task<ICollection<AllGameViewModel>> AllAsync();

        Task<int> CreateAsync(FormGameViewModel gameModel, string userId);

        Task EditAsync(FormGameViewModel gameModel, int gameId);

        Task<GameViewModel> GetByIdAsync(int gameId);

        Task<FormGameViewModel> GetForEditByIdAsync(int gameId);

        Task<DeleteGameViewModel> GetForDeleteByIdAsync(int gameId);


        Task<bool> IsOwnerAsync(string userId, int gameId);

        Task<bool> ExistAsync(int gameId);

        Task Delete(int gameId);
    }
}
