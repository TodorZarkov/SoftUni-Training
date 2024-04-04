namespace Watchlist.Models
{
    using static ValidationConstants.UserConstants;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;

    public class RegisterDTO : LoginDTO
    {
        [EmailAddress]
        [StringLength(maximumLength: EmailMaxLength, MinimumLength = EmailMinLength)]
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; } = null!;


        [DataType(DataType.Password)]
        [Compare("Password")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; } = null!;

    }
}
