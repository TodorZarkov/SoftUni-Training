namespace Boardgames.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

[XmlType("Creator")]
public class CreatorDtoImport
{

    [Required]
    [MinLength(2)]
    [MaxLength(7)]
    public string? FirstName { get; set; } = null!;

    [Required]
    [MinLength(2)]
    [MaxLength(7)]
    public string? LastName { get; set; } = null!;

    [XmlArray("Boardgames")]
    public BoardgameDtoImport[]? Boardgames { get; set; }
}
