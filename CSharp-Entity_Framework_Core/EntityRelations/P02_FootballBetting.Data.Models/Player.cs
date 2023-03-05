namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations.Schema;

public class Player
{
    public Player()
    {
        PlayersStatistics = new HashSet<PlayerStatistic>();
    }


    public int PlayerId { get; set; }

    [Column(TypeName = "nvarchar(300)")]
    public string Name { get; set; }

    public int SquadNumber { get; set; }

    public int TeamId { get; set; }
    public Team Team { get; set; }

    public int PositionId { get; set; }
    public Position Position { get; set; }

    public bool IsInjured { get; set; }

    
    public ICollection<PlayerStatistic> PlayersStatistics { get; set; }
}
