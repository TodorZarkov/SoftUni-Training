namespace Library.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class LibraryUser : IdentityUser
    {
        public ICollection<UserBook> UsersBooks { get; set; } = new HashSet<UserBook>();
    }
}
