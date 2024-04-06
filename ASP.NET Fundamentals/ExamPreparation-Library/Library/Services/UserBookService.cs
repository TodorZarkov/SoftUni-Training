namespace Library.Services
{
    using Library.Data;
    using Library.Services.Contracts;
    using System.Threading.Tasks;

    public class UserBookService : IUserBookService
    {
        private readonly LibraryDbContext dbContext;

        public UserBookService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        public async Task AddToCollectionAsync(int bookId, string userId)
        {
            var userBook = await dbContext.UsersBooks.FindAsync(userId, bookId);
            if (userBook != null)
            {
                return;
            }

            userBook = new IdentityUserBook
            {
                BookId = bookId,
                CollectorId = userId
            };

            await dbContext.UsersBooks.AddAsync(userBook);
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveFromCollectionAsync(int bookId, string userId)
        {
            var userBook = await dbContext.UsersBooks.FindAsync(userId, bookId);
            if (userBook == null)
            {
                return;
            }

            dbContext.Remove(userBook);
            await dbContext.SaveChangesAsync();
        }
    }
}
