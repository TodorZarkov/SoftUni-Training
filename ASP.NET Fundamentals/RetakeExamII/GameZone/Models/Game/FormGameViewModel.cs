namespace GameZone.Models.Game
{
	using GameZone.Models.Genre;
	using static ValidationConstants.GameConstants;

	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel;

	public class FormGameViewModel
	{
		[Required(AllowEmptyStrings = false)]
		[StringLength(maximumLength: TitleMax, MinimumLength = TitleMin)]
		[DisplayName("Game Title")]
		public string Title { get; set; } = null!;


		[Required(AllowEmptyStrings = false)]
		[StringLength(maximumLength: DescriptionMax, MinimumLength = DescriptionMin)]
		public string Description { get; set; } = null!;


		public string? ImageUrl { get; set; }


		[Required]
		[DisplayName("Released On")]
		public DateTime ReleasedOn { get; set; }


		[Required]
		public int GenreId { get; set; }

	
		public GenreViewModel[]? Genres { get; set; }

	}
}
//• Has Id – a unique integer, Primary Key
//• Has Title – a string with min length 2 and max length 50 (required)
//• Has Description – string with min length 10 and max length 500 (required)
//• Has ImageUrl – nullable string
//• Has PublisherId – string (required)
//• Has Publisher – IdentityUser (required)
//• Has ReleasedOn– DateTime with format " yyyy-MM-dd" (required) (the DateTime format is recommended, if you are having troubles with this one, you are free to use another one)
//• Has GenreId – integer, foreign key (required)
//• Has Genre – Genre (required)
//• Has GamersGames – a collection of type GamerGame