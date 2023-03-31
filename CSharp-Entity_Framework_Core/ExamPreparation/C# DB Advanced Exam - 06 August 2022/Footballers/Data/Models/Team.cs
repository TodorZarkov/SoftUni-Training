namespace Footballers.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Team
{
    public Team()
    {
        TeamsFootballers = new HashSet<TeamFootballer>();
    }


    public int Id { get; set; }

    [MinLength(3)]
    [MaxLength(40)]
    [RegularExpression(@"[a-zA-Z0-9 \.\-]+")]
    public string Name { get; set; } = null!;

    [MinLength(2)]
    [MaxLength(40)]
    public string Nationality { get; set; } = null!;

    public int Trophies { get; set; }

    public ICollection<TeamFootballer> TeamsFootballers { get; set; }
}
