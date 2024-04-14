namespace SoftUniBazar.Data
{
	using System.ComponentModel.DataAnnotations;
	using static ValidationConstants.CategoryConstants;

	public class Category
	{
        public Category()
        {
			Ads = new HashSet<Ad>();
        }


        [Key]
		public int Id { get; set; }

		[Required(AllowEmptyStrings = false)]
		[MaxLength(NameMax)]
		public string Name { get; set; } = null!;


		public ICollection<Ad> Ads { get; set; } = null!;
	}
}
//• Has Id – a unique integer, Primary Key
//• Has Name – a string with min length 3 and max length 15 (required)
//• Has Ads – a collection of type Ad