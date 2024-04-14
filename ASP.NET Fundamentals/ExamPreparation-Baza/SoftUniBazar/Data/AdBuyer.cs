namespace SoftUniBazar.Data
{
	using Microsoft.AspNetCore.Identity;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class AdBuyer
	{
		[ForeignKey(nameof(Buyer))]
		[Required(AllowEmptyStrings = false)]
		public string BuyerId { get; set; } = null!;

		[Required]
		public IdentityUser Buyer { get; set; } = null!;



		[ForeignKey(nameof(Ad))]
		[Required]
		public int AdId { get; set; }

		[Required]
		public Ad Ad { get; set; } = null!;

	}
}