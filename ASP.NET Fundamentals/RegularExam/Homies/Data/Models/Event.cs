
namespace Homies.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.EntityValidationConstants.Event;
    public class Event
    {
        public Event()
        {
            EventsParticipants = new HashSet<EventParticipant>();
        }


        [Key]
        public int Id { get; set; }


        [Required]
        [MaxLength(EventNameMax)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(EventDescriptionMax)]
        public string Description { get; set; } = null!;


        [Required]
        [ForeignKey(nameof(Organiser))]
        public string OrganiserId { get; set; } = null!;

        [Required]
        public IdentityUser Organiser { get; set; } = null!;


        public DateTime CreatedOn { get; set; }


        public DateTime Start { get; set; }


        public DateTime End { get; set; }


        [Required]
        [ForeignKey(nameof(Type))]
        public int TypeId { get; set; }


        [Required]
        public Data.Models.Type Type { get; set; } = null!;


        public ICollection<EventParticipant> EventsParticipants { get; set; }

    }
}
