namespace GameZone.Data
{
	using Microsoft.AspNetCore.Identity;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class GamerGame
	{
		[ForeignKey(nameof(Gamer))]
		[Required(AllowEmptyStrings = false)]
		public string GamerId { get; set; } = null!;

		[Required]
		public IdentityUser Gamer { get; set; } = null!;



		[ForeignKey(nameof(Game))]
		[Required]
		public int GameId { get; set; }

		[Required]
		public Game Game { get; set; } = null!;
	}
}
    //• Has GameId – integer, PrimaryKey, foreign key (required)
    //• Has Game – Game
    //• Has GamerId – string, PrimaryKey, foreign key (required)
    //• Has Gamer – IdentityUser