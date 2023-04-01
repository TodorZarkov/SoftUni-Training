namespace Trucks.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Despatcher
{
    public Despatcher()
    {
        Trucks = new HashSet<Truck>();
    }

    public int Id { get; set; }

    [Required]
    [MinLength(2)]
    [MaxLength(40)]
    public string Name { get; set; } = null!;

    public string? Position { get; set; }

    public ICollection<Truck> Trucks { get; set; }
}
