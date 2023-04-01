namespace Trucks.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Trucks.Data.Models.Enums;
using Trucks.Data.Models;
using System.Xml.Serialization;

[XmlType("Truck")]
public class TruckDtoImport
{
    [MinLength(8)]
    [MaxLength(8)]
    [RegularExpression(@"^[A-Z]{2}[0-9]{4}[A-Z]{2}$")]
    public string? RegistrationNumber { get; set; }

    [MinLength(17)]
    [MaxLength(17)]
    [Required]
    public string VinNumber { get; set; }

    [Required]//AMBIGUOUS
    [Range(950, 1420)]
    public int TankCapacity { get; set; }

    [Required]//AMBIGUOUS
    [Range(5000, 29000)]
    public int CargoCapacity { get; set; }

    [Required]
    [Range(0,3)]
    public int CategoryType { get; set; } //int parse string problem invalid xml!!!

    [Required]
    [Range(0, 4)]
    public int MakeType { get; set; } //int parse string problem invalid xml!!!
}
