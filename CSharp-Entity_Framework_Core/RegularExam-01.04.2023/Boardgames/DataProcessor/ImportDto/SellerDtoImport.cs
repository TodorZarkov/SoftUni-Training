namespace Boardgames.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;

public class SellerDtoImport
{
    [Required]
    [MinLength(5)]
    [MaxLength(20)]
    public string Name { get; set; } = null!;

    [Required]
    [MinLength(2)]
    [MaxLength(30)]
    public string Address { get; set; } = null!;

    [Required]
    public string Country { get; set; } = null!;

    [Required]
    [RegularExpression(@"^www\.[A-Za-z\-]+\.com$")]
    public string Website { get; set; } = null!;

    public HashSet<int> Boardgames { get; set; } = null!;
}
