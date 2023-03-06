namespace MusicHub.Data.Models ;

using MusicHub.Common;
using MusicHub.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

public class Song
{
    public Song()
    {
        SongPerformers = new HashSet<SongPerformer>();
    }
    public int Id { get; set; }

    [MaxLength(ValidationConstants.SongNameMaxLength)]
    public string Name { get; set; } = null!;

    public TimeSpan Duration { get; set; }

    public DateTime CreatedOn { get; set; }

    public Genre Genre { get; set; }

    public int? AlbumId { get; set; }
    public Album? Album { get; set; }

    public int WriterId { get; set; }
    public Writer Writer { get; set; } = null!;

    //Warning: The default sql server type is decimal(18,2)
    public decimal Price { get; set; }

    public ICollection<SongPerformer> SongPerformers { get; set; }
}
