namespace GameZone.Data
{
	using static ValidationConstants.GenreConstants;

	using System.ComponentModel.DataAnnotations;

	public class Genre
	{
        public Genre()
        {
			Games = new HashSet<Game>();
        }



        [Key]
		public int Id { get; set; }

		[Required(AllowEmptyStrings = false)]
		[MaxLength(NameMax)]
		public string Name { get; set; } = null!;


		public ICollection<Game> Games { get; set; } = null!;
	}
}
    //• Has Id – a unique integer, Primary Key
    //• Has Name – a string with min length 3 and max length 25 (required)
    //• Has Games – a collection of type Game