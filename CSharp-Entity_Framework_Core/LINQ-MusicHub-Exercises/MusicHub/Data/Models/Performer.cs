namespace MusicHub.Data.Models;

using MusicHub.Common;
using System.ComponentModel.DataAnnotations;

public class Performer
{
    public Performer()
    {
        PerformerSongs = new HashSet<SongPerformer>();
    }
    public int Id { get; set; }

    [MaxLength(ValidationConstants.PerformerFirstNameMaxLength)]
    public string FirstName { get; set; }

    [MaxLength(ValidationConstants.PerformerLastNameMaxLength)]
    public string LastName { get; set; }

    public int Age { get; set; }

    public decimal NetWorth { get; set; }

    public ICollection<SongPerformer> PerformerSongs { get; set; }
}
