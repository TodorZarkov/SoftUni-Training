namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations.Schema;

public class Color
{
    public Color()
    {
        SecondaryKitTeams = new HashSet<Team>();
        PrimaryKitTeams = new HashSet<Team>();
    }


    public int ColorId { get; set; }

    [Column(TypeName = "varchar(200)")]
    public string Name { get; set; }

    //[InverseProperty(nameof(Team.PrimaryKitColor))]
    public ICollection<Team> SecondaryKitTeams { get; set; }

    //[InverseProperty(nameof(Team.SecondaryKitColor))]
    public ICollection<Team> PrimaryKitTeams { get; set; }
}
