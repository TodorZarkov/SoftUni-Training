namespace Trucks.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;
using Trucks.Data.Models.Enums;

public class Truck
{
    public Truck()
    {
        ClientsTrucks = new HashSet<ClientTruck>();
    }


    public int Id { get; set; }

    [MinLength(8)]
    [MaxLength(8)]
    [RegularExpression(@"^[A-Z]{2}[0-9]{4}[A-Z]{2}$")]
    public string? RegistrationNumber { get; set; }

    [MinLength(17)]
    [MaxLength(17)]
    [Required]
    public string VinNumber { get; set; } = null!;

    [Range(950,1420)]
    public int TankCapacity { get; set; }

    [Range(5000, 29000)]
    public int CargoCapacity { get; set; }

    [Required]
    public CategoryType CategoryType { get; set; }

    [Required]
    public MakeType MakeType { get; set; }

    [Required]
    [ForeignKey(nameof(Despatcher))]
    public int DespatcherId { get; set; }
    public Despatcher Despatcher { get; set; } = null!;

    public ICollection<ClientTruck> ClientsTrucks { get; set; }
}
