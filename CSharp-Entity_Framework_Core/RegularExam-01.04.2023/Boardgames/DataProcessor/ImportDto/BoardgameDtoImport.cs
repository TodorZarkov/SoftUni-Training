namespace Boardgames.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

[XmlType("Boardgame")]
public class BoardgameDtoImport
{
    [Required]
    [MinLength(10)]
    [MaxLength(20)]
    public string Name { get; set; } = null!;

    [Required]
    [Range(1, 10.00)]
    public double Rating { get; set; } //as string?!

    [Required]
    [Range(2018, 2023)]
    public int YearPublished { get; set; } //as string?!

    [Required]
    [Range(0,4)]
    public int CategoryType { get; set; } //as string?!

    [Required]
    public string Mechanics { get; set; } = null!;
}
