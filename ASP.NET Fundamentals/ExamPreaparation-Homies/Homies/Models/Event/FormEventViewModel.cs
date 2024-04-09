namespace Homies.Models.Event
{
    using Homies.Data;

    using static ValidationConstants.EventConstants;

    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using Homies.Models.Type;

    public class FormEventViewModel
    {
        [Required(AllowEmptyStrings = false)]
        [StringLength(maximumLength: NameMax, MinimumLength = NameMin)]
        public string Name { get; set; } = null!;


        [Required(AllowEmptyStrings = false)]
        [StringLength(maximumLength: DescriptionMax, MinimumLength = DescriptionMin)]
        public string Description { get; set; } = null!;


        [Required]
        public DateTime Start { get; set; }


        [Required]
        public DateTime End { get; set; }


        [Required]
        //dynamic validation
        public int TypeId { get; set; }
        public TypeViewModel[]? Types { get; set; }


    }
}
