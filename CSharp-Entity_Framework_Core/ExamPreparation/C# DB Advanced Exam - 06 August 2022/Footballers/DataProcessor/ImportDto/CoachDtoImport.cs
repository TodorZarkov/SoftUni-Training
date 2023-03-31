namespace Footballers.DataProcessor.ImportDto;

using Footballers.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

[XmlType("Coach")]
public class CoachDtoImport
{
    public string? Name { get; set; }


    public string? Nationality { get; set; }


    [XmlArray("Footballers")]
    public FootballerDtoImport[] Footballers { get; set; }
}
