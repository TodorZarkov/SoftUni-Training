namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

public class Bet
{
    public int BetId { get; set; }

    [Column(TypeName = "decimal(38,16)")]
    public decimal Amount { get; set; }

    [Column(TypeName = "varchar(7)")]
    public string Prediction { get; set; }

    public DateTime DateTime { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public int GameId { get; set; }
    public Game Game { get; set; }
}
