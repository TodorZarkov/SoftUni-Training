namespace Watchlist.Models
{
    using static ValidationConstants.UserConstants;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;

    public class UserDTO
    {
        [StringLength(maximumLength: NameMaxLength, MinimumLength = NameMinLength)]
        [Required(AllowEmptyStrings = false)]
        [DisplayName("Username")]
        public string UserName { get; set; } = null!;


        [StringLength(maximumLength: EmailMaxLength, MinimumLength = EmailMinLength)]
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; } = null!;


        [StringLength(maximumLength: PassMaxLength, MinimumLength = PassMinLength)]
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; } = null!;


        [Compare("Password")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; } = null!;

    }
}
