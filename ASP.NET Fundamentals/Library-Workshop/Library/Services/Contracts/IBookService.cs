namespace Library.Services.Contracts
{
    using Library.ViewModels.Book;
    public interface IBookService
    {
        Task<ICollection<AllBookViewModel>> GetAllBooksAsync();

        Task<ICollection<MineBookViewModel>> GetAllBooksAsync(string userId);

        Task AddToUserAsync(int bookId, string userId);

        Task RemoveFromUserAsync(int bookId, string userId);

        Task AddAsync(FormBookViewModel viewModel);
    }
}
