namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations.Schema;

public class Country
{
    public Country()
    {
        Towns = new HashSet<Town>();
    }

    public int CountryId { get; set; }

    [Column(TypeName = "nvarchar(200)")]
    public string Name { get; set; }

    public ICollection<Town> Towns { get; set; }
}
