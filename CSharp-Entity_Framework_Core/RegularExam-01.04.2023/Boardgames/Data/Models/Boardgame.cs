namespace Boardgames.Data.Models;

using Boardgames.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

public class Boardgame
{
    public Boardgame()
    {
        BoardgamesSellers = new HashSet<BoardgameSeller>();
    }


    public int Id { get; set; }

    [MaxLength(20)]
    public string Name { get; set; } = null!;

    public double Rating { get; set; }

    public int YearPublished { get; set; }

    public CategoryType CategoryType { get; set; }

    public string Mechanics { get; set; } = null!;

    public int CreatorId { get; set; }

    public Creator Creator { get; set; } = null!;

    public ICollection<BoardgameSeller> BoardgamesSellers { get; set; }
}
