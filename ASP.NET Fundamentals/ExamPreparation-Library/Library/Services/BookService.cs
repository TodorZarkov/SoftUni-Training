namespace Library.Services
{
    using Library.Data;
    using Library.Models.Book;
    using Library.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class BookService : IBookService
    {
        private readonly LibraryDbContext dbContext;

        public BookService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<ICollection<AllBookDto>> AllAsync()
        {
            var books = await dbContext.Books
                .AsNoTracking()
                .Select(b => new AllBookDto
                {
                    Author = b.Author,
                    Category = b.Category.Name,
                    Id = b.Id,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating.ToString("#,00"),
                    Title = b.Title
                })
                .ToArrayAsync();

            return books;
        }

        public async Task<int> CreateAsync(FormBookDto model)
        {
            Book book = new Book
            {
                CategoryId = model.CategoryId,
                Author = model.Author,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                Title = model.Title
            };

            await dbContext.Books.AddAsync(book);
            await dbContext.SaveChangesAsync();

            return book.Id;
        }

        public async Task<ICollection<MineBookDto>> MineAsync(string userId)
        {
            var mine = await dbContext.UsersBooks
                .AsNoTracking()
                .Where(ub => ub.CollectorId == userId)
                .Select(ub => new MineBookDto
                {
                    Author = ub.Book.Author,
                    Category = ub.Book.Category.Name,
                    Id = ub.Book.Id,
                    ImageUrl = ub.Book.ImageUrl,
                    Title = ub.Book.Title,
                    Description = ub.Book.Description
                })
                .ToArrayAsync();

            return mine;
        }

    }
}
