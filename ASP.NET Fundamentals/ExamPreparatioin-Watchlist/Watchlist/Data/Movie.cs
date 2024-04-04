namespace Watchlist.Data
{
    using static ValidationConstants.MovieConstants;

	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

    public class Movie
    {
        public Movie()
        {
            UsersMovies = new HashSet<UserMovie>();
        }

        [Key]
        public int Id { get; set; }

		[Required(AllowEmptyStrings = false)]
        [MaxLength(TitleMaxLength)]		
        public string Title { get; set; } = null!;

		[Required(AllowEmptyStrings = false)]
		[MaxLength(DirectorMaxLength)]
        public string Director { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public decimal Rating { get; set; }

        [Required]
        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }
        [Required]
        public Genre Genre { get; set; } = null!;

        public ICollection<UserMovie> UsersMovies { get; set; } = null!;
    }
}
