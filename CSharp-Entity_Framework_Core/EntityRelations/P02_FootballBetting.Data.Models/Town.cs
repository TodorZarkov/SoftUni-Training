namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations.Schema;

public class Town
{
    public Town()
    {
        Teams = new HashSet<Team>();
    }


    public int TownId { get; set; }

    [Column(TypeName = "nvarchar(200)")]
    public string Name { get; set; }

    public int CountryId { get; set; }
    public Country Country { get; set; }

    public ICollection<Team> Teams { get; set; }
}
