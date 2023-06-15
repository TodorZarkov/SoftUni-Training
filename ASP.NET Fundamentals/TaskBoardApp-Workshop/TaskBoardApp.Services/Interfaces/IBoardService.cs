namespace TaskBoardApp.Services.Interfaces
{
    using TaskBoardApp.Web.ViewModels.Board;

    public interface IBoardService
    {
        Task<IEnumerable<BoardAllViewModel>> AllAsync();

        Task<ICollection<BoardCountViewModel>> AllWithTasksAsync();

        Task<IEnumerable<BoardSelectViewModel>> AllForSelectAsync();

        Task<bool> ExistsByIdAsync(int id);

    }
}
