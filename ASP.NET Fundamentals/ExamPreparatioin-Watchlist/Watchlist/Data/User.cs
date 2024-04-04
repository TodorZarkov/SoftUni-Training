namespace Watchlist.Data
{
	using Microsoft.AspNetCore.Identity;
	using System.ComponentModel.DataAnnotations;

	public class User : IdentityUser
	{
        public User()
        {
			UsersMovies = new HashSet<UserMovie>();
        }
		
        [Required(AllowEmptyStrings = false)] 
		override public string UserName { get; set; } = null!;

		[Required(AllowEmptyStrings = false)]
		override public string Email { get; set; } = null!;


		[Required(AllowEmptyStrings = false)]
		public override string PasswordHash { get; set; } = null!;

		public ICollection<UserMovie> UsersMovies { get; set; } = null!;
    }
}
