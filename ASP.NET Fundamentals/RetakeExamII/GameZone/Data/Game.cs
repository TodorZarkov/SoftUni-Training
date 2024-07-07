using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace GameZone.Data
{
	using static ValidationConstants.GameConstants;
	public class Game
	{
        public Game()
        {
			GamersGames = new HashSet<GamerGame>();
        }



        [Key]
		public int Id { get; set; }


		[Required(AllowEmptyStrings = false)]
		[MaxLength(TitleMax)]
		public string Title { get; set; } = null!;


		[Required(AllowEmptyStrings = false)]
		[MaxLength(DescriptionMax)]
		public string Description { get; set; } = null!;

		
		public string? ImageUrl { get; set; }


		[Required]
		[ForeignKey(nameof(Publisher))]
		public string PublisherId { get; set; } = null!;

		[Required]
		public IdentityUser Publisher { get; set; } = null!;


		[Required]
		public DateTime ReleasedOn { get; set; }


		[Required]
		[ForeignKey(nameof(Genre))]
		public int GenreId { get; set; }

		[Required]
		public Genre Genre { get; set; } = null!;




		public ICollection<GamerGame> GamersGames { get; set; }
	}
}
   