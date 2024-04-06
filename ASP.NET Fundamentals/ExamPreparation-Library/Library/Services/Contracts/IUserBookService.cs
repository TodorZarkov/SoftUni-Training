namespace Library.Services.Contracts
{
    public interface IUserBookService
    {

        Task AddToCollectionAsync(int bookId, string userId);

        Task RemoveFromCollectionAsync(int bookId, string userId);
    }
}
