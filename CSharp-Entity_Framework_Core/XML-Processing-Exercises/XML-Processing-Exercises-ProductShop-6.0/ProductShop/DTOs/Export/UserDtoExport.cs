namespace ProductShop.DTOs.Export;

using ProductShop.Models;
using System.Xml.Serialization;

[XmlType("User")]
public class UserDtoExport
{
    [XmlElement("firstName")]
    public string FirstName { get; set; } = null!;


    [XmlElement("lastName")]
    public string LastName { get; set; } = null!;


    [XmlArray("soldProducts")]
    public ProductWithNamePriceDtoExport[] ProductsSold { get; set; } = null!;
}
