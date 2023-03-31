namespace Footballers.DataProcessor.ExportDto;

using System.Xml.Serialization;

[XmlType("Coach")]
public class CoachDtoExport
{
    [XmlAttribute("FootballersCount")]
    public int FootballersCount { get; set; }


    [XmlElement("CoachName")]
    public string Name { get; set; } = null!;


    [XmlArray("Footballers")]
    public FootballersDtoExport[] Footballers { get; set; } = null!;
}
