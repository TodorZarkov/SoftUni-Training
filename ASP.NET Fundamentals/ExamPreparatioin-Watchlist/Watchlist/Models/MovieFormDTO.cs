namespace Watchlist.Models
{
    using static Watchlist.ValidationConstants.MovieConstants;

    using System.ComponentModel.DataAnnotations;

    public class MovieFormDTO
    {

        [Required(AllowEmptyStrings = false)]
        [StringLength(maximumLength: TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;


        [Required(AllowEmptyStrings = false)]
        [StringLength(maximumLength: DirectorMaxLength, MinimumLength = DirectorMinLength)]
        public string Director { get; set; } = null!;


        [Required(AllowEmptyStrings = false)]
        public string ImageUrl { get; set; } = null!;


        [Required(AllowEmptyStrings = false)]
        [Range(RatingMin, RatingMax)]
        public decimal Rating { get; set; }


        [Required]
        //dynamic validation
        public int GenreId { get; set; }

        public ICollection<GenreSelectDTO>? AvailableGenres { get; set; }
    }
}
