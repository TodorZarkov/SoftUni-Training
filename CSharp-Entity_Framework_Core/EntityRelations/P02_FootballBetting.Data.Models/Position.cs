namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations.Schema;

public class Position
{
    public Position()
    {
        Players = new HashSet<Player>();
    }


    public int PositionId { get; set; }

    [Column(TypeName = "nvarchar(100)")]
    public string Name { get; set; }

    public ICollection<Player> Players { get; set; }
}
