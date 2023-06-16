using Library.ViewModels.Book;

namespace Library.Services.Contracts
{
    public interface IBookService
    {
        Task<ICollection<AllBookViewModel>> GetAllBooksAsync();

        Task<ICollection<AllBookViewModel>> GetAllBooksAsync(string userId);
    }
}
