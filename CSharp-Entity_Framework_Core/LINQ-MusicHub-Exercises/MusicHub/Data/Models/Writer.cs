namespace MusicHub.Data.Models;

using MusicHub.Common;
using System.ComponentModel.DataAnnotations;

public class Writer
{
    public Writer()
    {
        Songs = new HashSet<Song>(); 
    }
    public int Id { get; set; }

    [MaxLength(ValidationConstants.WriterNameMaxLength)]
    public string Name { get; set; }

    [MaxLength(ValidationConstants.WriterPseudonymMaxLength)]
    public string? Pseudonym { get; set; }

    public ICollection<Song> Songs { get; set; }
}
