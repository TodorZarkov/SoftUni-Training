namespace Homies.Data
{
	using static ValidationConstants.EventConstants;

	using System.ComponentModel.DataAnnotations.Schema;
	using System.ComponentModel.DataAnnotations;
	using Microsoft.AspNetCore.Identity;

	public class Event
	{
		public Event()
		{
			EventsParticipants = new HashSet<EventParticipant>();
		}


		[Key]
		public int Id { get; set; }


		[Required(AllowEmptyStrings = false)]
		[MaxLength(NameMax)]
		public string Name { get; set; } = null!;


		[Required(AllowEmptyStrings = false)]
		[MaxLength(DescriptionMax)]
		public string Description { get; set; } = null!;


		[Required]
		[ForeignKey(nameof(Organiser))]
		public string OrganiserId { get; set; } = null!;

		[Required]
		public IdentityUser Organiser { get; set; } = null!;


        [Required]
        public DateTime CreatedOn { get; set; }


        [Required]
        public DateTime Start { get; set; }


        [Required]
        public DateTime End { get; set; }


        [Required]
		[ForeignKey(nameof(Homies.Data.Type))]
        public int TypeId { get; set; }

		[Required]
		public Homies.Data.Type Type { get; set; } = null!;


        public ICollection<EventParticipant> EventsParticipants { get; set; }
        
    }
}
