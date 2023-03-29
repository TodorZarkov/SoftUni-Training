namespace ProductShop.DTOs.Export;

using System.Xml.Serialization;

[XmlType("User")]
public class UserNamesAgeDtoExport
{
    [XmlElement("firstName")]
    public string FirstName { get; set; } = null!;

    [XmlElement("lastName")]
    public string LastName { get; set; } = null!;

    [XmlElement("age")]
    public int? Age { get; set; }

    [XmlElement("SoldProducts")]
    public SoldProductsDtoExport SoldProducts { get; set; } = null!;
}
