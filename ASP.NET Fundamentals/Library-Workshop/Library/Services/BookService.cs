using Library.Data;
using Library.Data.Models;
using Library.Services.Contracts;
using Library.ViewModels.Book;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

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
            //unusual case if book id doesn't eixst, to catch
            bool isValidBookId = await dbContext.Books.AnyAsync(b => b.Id == bookId);
            if (!isValidBookId)
            {
                throw new InvalidOperationException("The book id not present in the database!");
            }


            bool isAdded = await dbContext.IdentityUserBook
                .AnyAsync(ub => ub.BookId == bookId && ub.CollectorId == userId);
            if (isAdded)
            {
                //usual case pair aready exists exception from the app, to catch
                throw new InvalidOperationException("The book already is in the user collection!");
            }
            //the previous two checks are also made in the db

            IdentityUserBook userBook = new IdentityUserBook()
            {
                BookId = bookId,
                CollectorId = userId
            };
            dbContext.IdentityUserBook.Add(userBook); 
            //unusual case not existing foreign key if book isn't present in the database
            //usual case pair aready exists exception from the database, to catch
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
            //to catch if pair doesnt exist (unusual case)
            IdentityUserBook userBook = await dbContext
                .IdentityUserBook
                .FirstAsync(ub => ub.BookId == bookId && ub.CollectorId == userId);
            
            dbContext.IdentityUserBook.Remove(userBook);

            await dbContext.SaveChangesAsync();
        }
    }
}
