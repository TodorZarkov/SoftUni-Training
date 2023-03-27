namespace ProductShop.DTOs.Import;

using System.Xml.Serialization;

[XmlType("Category")]
public class CategoryDtoImport
{
    [XmlElement("name")]
    public string Name { get; set; } = null!;
}
