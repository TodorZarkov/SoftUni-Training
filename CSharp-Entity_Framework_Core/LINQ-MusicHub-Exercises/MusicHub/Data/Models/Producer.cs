namespace MusicHub.Data.Models;

using MusicHub.Common;
using System.ComponentModel.DataAnnotations;

public class Producer
{
    public Producer()
    {
        Albums = new HashSet<Album>();
    }
    public int Id { get; set; }

    [MaxLength(ValidationConstants.ProducerNameMaxLength)]
    public string Name { get; set; }

    [MaxLength(ValidationConstants.ProducerPseudonymMaxLength)]
    public string? Pseudonym { get; set; }

    [MaxLength(ValidationConstants.ProducerPhoneNumberMaxLength)]
    public string? PhoneNumber { get; set; }

    public ICollection<Album> Albums { get; set; } = null!;
}
