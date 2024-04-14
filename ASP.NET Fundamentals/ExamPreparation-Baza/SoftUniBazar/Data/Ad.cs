namespace SoftUniBazar.Data
{
	using Microsoft.AspNetCore.Identity;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using static ValidationConstants.AdConstants;

	public class Ad
	{
		[Key]
		public int Id { get; set; }


		[Required(AllowEmptyStrings = false)]
		[MaxLength(NameMax)]
		public string Name { get; set; } = null!;


		[Required(AllowEmptyStrings = false)]
		[MaxLength(DescriptionMax)]
		public string Description { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }


		[Required]
		[ForeignKey(nameof(Owner))]
		public string OwnerId { get; set; } = null!;

		[Required]
		public IdentityUser Owner { get; set; } = null!;


		[Required(AllowEmptyStrings = false)]
		public string ImageUrl { get; set; } = null!;


        [Required]
        public DateTime CreatedOn { get; set; }


		[Required]
		[ForeignKey(nameof(Category))]
		public int CategoryId { get; set; }

		[Required]
		public Category Category { get; set; } = null!;

		public ICollection<AdBuyer> AdsBuyers { get; set; } = null!;
	}
}

