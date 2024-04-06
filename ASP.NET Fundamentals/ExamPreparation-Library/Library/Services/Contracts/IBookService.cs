namespace Library.Services.Contracts
{
    using Library.Models.Book;

    public interface IBookService
    {
        Task<ICollection<AllBookDto>> AllAsync();

        Task<ICollection<MineBookDto>> MineAsync(string userId);

        Task<int> CreateAsync(FormBookDto bookModel);

    }
}
