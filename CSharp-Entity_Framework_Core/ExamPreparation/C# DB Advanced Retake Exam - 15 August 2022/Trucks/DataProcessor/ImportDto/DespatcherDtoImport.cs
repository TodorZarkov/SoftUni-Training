namespace Trucks.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Trucks.Data.Models;

[XmlType("Despatcher")]
public class DespatcherDtoImport
{

    [Required]
    [MinLength(2)]
    [MaxLength(40)]
    public string? Name { get; set; }

    [Required]
    [MinLength(1)]
    public string Position { get; set; }

    [XmlArray("Trucks")]
    public TruckDtoImport[] Trucks { get; set; }
}
