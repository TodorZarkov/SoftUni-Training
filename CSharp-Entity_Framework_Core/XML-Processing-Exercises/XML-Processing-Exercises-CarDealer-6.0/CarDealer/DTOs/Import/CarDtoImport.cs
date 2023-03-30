namespace CarDealer.DTOs.Import;

using System.Xml.Serialization;

[XmlType("Car")]
public class CarDtoImport
{
    public CarDtoImport()
    {
        PartIds = new HashSet<PartIdDtoImport>();
    }

    [XmlElement("make")]
    public string Make { get; set; } = null!;

    [XmlElement("model")]
    public string Model { get; set; } = null!;

    [XmlElement("traveledDistance")]
    public long TraveledDistance { get; set; }

    [XmlArray("parts")]
    public HashSet<PartIdDtoImport> PartIds { get; set; }
        
}


