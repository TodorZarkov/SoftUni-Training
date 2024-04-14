namespace SoftUniBazar.Models.Ad
{
	using Microsoft.AspNetCore.Identity;
	using SoftUniBazar.Data;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.ComponentModel.DataAnnotations;

	using static ValidationConstants.AdConstants;
	using SoftUniBazar.Models.Category;

	public class FormAdViewModel
	{

		[Required(AllowEmptyStrings = false)]
		[StringLength(maximumLength: NameMax, MinimumLength = NameMin)]
		public string Name { get; set; } = null!;


		[Required(AllowEmptyStrings = false)]
		[StringLength(maximumLength: DescriptionMax, MinimumLength = DescriptionMin)]
		public string Description { get; set; } = null!;

		[Required]
		public decimal Price { get; set; }



		[Required(AllowEmptyStrings = false)]
		public string ImageUrl { get; set; } = null!;




		[Required]
		//dynamic validation here
		public int CategoryId { get; set; }

		public CategoryViewModel[]? Categories { get; set; }

	}
}
//• Has Id – a unique integer, Primary Key
//• Has Name – a string with min length 5 and max length 25 (required)
//• Has Description – a string with min length 15 and max length 250 (required)
//• Has Price – a decimal (required)
//• Has OwnerId – a string (required)
//• Has Owner – an IdentityUser (required)
//• Has ImageUrl – a string (required)
//• Has CreatedOn – a DateTime with format "yyyy-MM-dd H:mm" (required) (the DateTime format is recommended, if you are having troubles with this one, you are free to use another one)
//• Has CategoryId – an integer, foreign key (required)
//• Has Category – a Category (required)