namespace Footballers.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Coach
{
    public Coach()
    {
        Footballers = new HashSet<Footballer>();
    }


    public int Id { get; set; }

    //[MinLength(2)]
    [MaxLength(40)]
    public string Name { get; set; } = null!;

    public string Nationality { get; set; } = null!;

    public ICollection<Footballer> Footballers { get; set; }
}
