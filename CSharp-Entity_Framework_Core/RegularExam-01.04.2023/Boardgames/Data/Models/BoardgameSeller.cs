namespace Boardgames.Data.Models;

using System.ComponentModel.DataAnnotations;

public class BoardgameSeller
{
    public int BoardgameId { get; set; }
    public Boardgame Boardgame { get; set; } = null!;

    public int SellerId { get; set; }
    public Seller Seller { get; set; } = null!;
}
