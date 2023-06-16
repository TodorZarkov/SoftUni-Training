using Library.Data;
using Library.Data.Models;
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

        public async Task AddAsync(FormBookViewModel viewModel)
        {
            Book book = new Book()
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                Author = viewModel.Author,
                ImageUrl = viewModel.Url,
                CategoryId = viewModel.CategoryId,
                Rating = viewModel.Rating
            };
            await dbContext.Books.AddAsync(book);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddToUserAsync(int bookId, string userId)
        {
            Book book = await dbContext.Books.FirstAsync(b => b.Id == bookId);//chatch not existin book id

            IdentityUserBook userBook = new IdentityUserBook()
            {
                BookId = bookId,
                CollectorId = userId
            };

            book.UsersBooks.Add(userBook); // pair aready exists
            await dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<AllBookViewModel>> GetAllBooksAsync()
        {
            var books = await dbContext.Books
                .AsNoTracking()
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

        public async Task<ICollection<MineBookViewModel>> GetAllBooksAsync(string userId)
        {
            var allBooks = await dbContext.Books
                .AsNoTracking()
                .Where(b => b.UsersBooks.Any(ub => ub.CollectorId == userId))
                .Select(b => new MineBookViewModel()
                {
                    Id = b.Id,
                    Description = b.Description,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating.ToString("N2"),
                    Title = b.Title,
                    Category = b.Category.Name
                })
                .ToArrayAsync();

            return allBooks;
        }

        public async Task RemoveFromUserAsync(int bookId, string userId)
        {
            IdentityUserBook userBook = await dbContext
                .IdentityUserBook
                .FirstAsync(ub => ub.BookId == bookId && ub.CollectorId == userId);
            
            dbContext.IdentityUserBook.Remove(userBook);

            await dbContext.SaveChangesAsync();
        }
    }
}
