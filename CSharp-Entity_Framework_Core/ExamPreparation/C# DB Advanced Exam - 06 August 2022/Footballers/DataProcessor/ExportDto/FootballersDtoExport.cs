namespace Footballers.DataProcessor.ExportDto;

using Footballers.Data.Models.Enums;
using System.Xml.Serialization;

[XmlType("Footballer")]
public class FootballersDtoExport
{
    [XmlElement("Name")]
    public string Name { get; set; } = null!;

    
    [XmlElement("Position")]
    public PositionType PositionType { get; set; }
}
