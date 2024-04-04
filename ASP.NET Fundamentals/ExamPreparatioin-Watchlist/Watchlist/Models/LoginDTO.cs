namespace Watchlist.Models
{
    using static ValidationConstants.UserConstants;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;

    public class LoginDTO
    {
        [StringLength(maximumLength: NameMaxLength, MinimumLength = NameMinLength)]
        [Required(AllowEmptyStrings = false)]
        [DisplayName("Username")]
        public string UserName { get; set; } = null!;


        [DataType(DataType.Password)]
        [StringLength(maximumLength: PassMaxLength, MinimumLength = PassMinLength)]
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; } = null!;

    }
}
