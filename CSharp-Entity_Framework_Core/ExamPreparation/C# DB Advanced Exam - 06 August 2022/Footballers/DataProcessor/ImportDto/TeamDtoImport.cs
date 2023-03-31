namespace Footballers.DataProcessor.ImportDto;

using Footballers.Data.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


public class TeamDtoImport
{
    public TeamDtoImport()
    {
        Footballers = new HashSet<int>();
    }

    [MinLength(3)]
    [MaxLength(40)]
    [RegularExpression(@"^[a-zA-Z0-9\s\.\-]+$")]
    [Required]
    public string? Name { get; set; }

    [MinLength(2)]
    [MaxLength(40)]
    [Required]
    public string? Nationality { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? Trophies { get; set; } //RISKY!! IT CAN BE STRING!!!

    public HashSet<int> Footballers { get; set; } //RISKY!! IT CAN BE STRING!!!
}
