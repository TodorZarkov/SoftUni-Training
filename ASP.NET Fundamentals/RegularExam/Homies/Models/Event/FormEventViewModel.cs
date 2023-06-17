namespace Homies.Models.Event
{
    using Homies.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Event;
    using Homies.Models.Type;

    public class FormEventViewModel
    {
        [Required]
        [StringLength(EventNameMax, MinimumLength = EventNameMin)]
        public string Name { get; set; } = null!;


        [Required]
        [StringLength(EventDescriptionMax, MinimumLength = EventDescriptionMin)]
        public string Description { get; set; } = null!;

        [Required]
        public string Start { get; set; } = null!;


        [Required]
        public string End { get; set; } = null!;


        [Required]
        public int TypeId { get; set; }


        public ICollection<TypeSelectViewModel>? Types { get; set; }
    }
}
