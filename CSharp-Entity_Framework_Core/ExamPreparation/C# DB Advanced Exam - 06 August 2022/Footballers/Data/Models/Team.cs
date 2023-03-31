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
    [RegularExpression(@"^[a-zA-Z0-9\s\.\-]+$")]
    public string Name { get; set; } = null!;

    [MinLength(2)]
    [MaxLength(40)]
    public string Nationality { get; set; } = null!;

    [Range(1,int.MaxValue)]
    public int Trophies { get; set; }

    //unique values guaranteed by the hashset<int> on the dto
    public ICollection<TeamFootballer> TeamsFootballers { get; set; }
}
