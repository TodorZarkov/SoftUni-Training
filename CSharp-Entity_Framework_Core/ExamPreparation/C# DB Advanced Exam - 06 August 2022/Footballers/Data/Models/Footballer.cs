namespace Footballers.Data.Models;

using Footballers.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

public class Footballer
{
    public Footballer()
    {
        TeamsFootballers = new HashSet<TeamFootballer>();
    }

    public int Id { get; set; }

    [MinLength(2)]
    [MaxLength(40)]
    public string Name { get; set; } = null!;

    public DateTime ContractStartDate { get; set; }

    public DateTime ContractEndDate { get; set; }

    public PositionType PositionType { get; set; }

    public BestSkillType BestSkillType { get; set; }

    public int CoachId { get; set; }
    public Coach Coach { get; set; }

    public ICollection<TeamFootballer> TeamsFootballers { get; set; }
}
