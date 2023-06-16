using Library.Data;
using Library.Services.Contracts;
using Library.ViewModels.Book;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext dbContext;
        public BookService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<ICollection<AllBookViewModel>> GetAllBooksAsync()
        {
            var books = await dbContext.Books
                .Select(b => new AllBookViewModel
                {
                    Id = b.Id,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating.ToString("N2"),
                    Title = b.Title,
                    Category = b.Category.Name
                })
                .ToArrayAsync();

            return books;
        }

        public Task<ICollection<AllBookViewModel>> GetAllBooksAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
