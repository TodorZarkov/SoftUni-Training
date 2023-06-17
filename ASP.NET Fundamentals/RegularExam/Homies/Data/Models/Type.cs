
namespace Homies.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Type;
    public class Type
    {
        public Type()
        {
            Events = new HashSet<Event>();
        }


        [Key]
        public int Id { get; set; }


        [Required]
        [MaxLength(TypeNameMax)]
        public string Name { get; set; } = null!;


        public ICollection<Event> Events { get; set; }
    }
}
