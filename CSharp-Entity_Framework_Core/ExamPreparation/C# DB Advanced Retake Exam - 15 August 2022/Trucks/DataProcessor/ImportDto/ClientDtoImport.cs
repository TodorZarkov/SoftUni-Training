namespace Trucks.DataProcessor.ImportDto;

using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Trucks.Data.Models;


public class ClientDtoImport
{
    [Required]
    [MinLength(3)]
    [MaxLength(40)]
    public string Name { get; set; } = null!;

    [Required]
    [MinLength(2)]
    [MaxLength(40)]
    public string Nationality { get; set; } = null!;

    [Required]
    [RegularExpression(@"^((?!usual).)*$")]
    public string Type { get; set; } = null!;


    public HashSet<int>? Trucks { get; set; } = new HashSet<int>();
}
