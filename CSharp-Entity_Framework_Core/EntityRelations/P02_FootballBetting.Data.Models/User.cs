namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    public User()
    {
        Bets = new HashSet<Bet>();
    }


    public int UserId { get; set; }

    [Column(TypeName = "nvarchar(200)")]
    public string Username { get; set; }

    [Column(TypeName = "nvarchar(200)")]
    public string Password { get; set; }

    [Column(TypeName = "varchar(200)")]
    public string Email { get; set; }

    [Column(TypeName = "nvarchar(200)")]
    public string? Name { get; set; }

    [Column(TypeName = "decimal(38,16)")]
    public decimal Balance { get; set; }

    public ICollection<Bet> Bets { get; set; }
}
