namespace Watchlist.Data
{
    using static Watchlist.ValidationConstants.GenreConstants;

    using System.ComponentModel.DataAnnotations;

    public class Genre
	{
        public Genre()
        {
			Movies = new HashSet<Movie>();
        }


        [Key]
		public int Id { get; set; }

		[Required(AllowEmptyStrings = false)]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; } = null!;

		public ICollection<Movie> Movies { get; set; } = null!;
    }
}
