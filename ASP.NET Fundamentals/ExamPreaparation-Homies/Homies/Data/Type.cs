namespace Homies.Data
{
    using static ValidationConstants.TypeConstants;

	using System.ComponentModel.DataAnnotations;

	public class Type
	{
        public Type()
        {
            Events = new HashSet<Event>();
        }


        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(NameMax)]
        public string Name { get; set; } = null!;


        public ICollection<Event> Events { get; set; } = null!;
    }
}
