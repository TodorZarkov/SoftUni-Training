namespace Homies.Data
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class EventParticipant
	{
        [ForeignKey(nameof(Helper))]
        [Required(AllowEmptyStrings = false)]
        public string HelperId { get; set; } = null!;

        [Required]
        public IdentityUser Helper { get; set; } = null!;



		[ForeignKey(nameof(Event))]
		[Required]
		public int EventId { get; set; }

		[Required]
		public Event Event { get; set; } = null!;


	}
}
