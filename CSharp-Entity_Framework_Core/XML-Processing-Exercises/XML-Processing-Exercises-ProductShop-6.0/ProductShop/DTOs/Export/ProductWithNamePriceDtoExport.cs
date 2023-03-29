namespace ProductShop.DTOs.Export;

using System.Xml.Serialization;

[XmlType("Product")]
public class ProductWithNamePriceDtoExport
{
    [XmlElement("name")]
    public string Name { get; set; } = null!;

    [XmlElement("price")]
    //public string Price { get; set; } = null!;
    public decimal Price { get; set; }
}
