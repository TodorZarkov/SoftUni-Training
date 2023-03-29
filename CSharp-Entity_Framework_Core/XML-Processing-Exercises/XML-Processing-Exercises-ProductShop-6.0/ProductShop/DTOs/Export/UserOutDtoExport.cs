namespace ProductShop.DTOs.Export;

using System.Xml.Serialization;

[XmlType("Users")]
public class UserOutDtoExport
{
    [XmlElement("count")]
    public int Count { get; set; }

    [XmlArray("users")]
    public UserNamesAgeDtoExport[] InUsers { get; set; } = null!;
}
