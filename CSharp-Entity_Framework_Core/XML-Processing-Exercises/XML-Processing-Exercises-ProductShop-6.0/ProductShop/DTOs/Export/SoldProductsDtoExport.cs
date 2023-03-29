namespace ProductShop.DTOs.Export;

using System.Xml.Serialization;

[XmlType("SoldProducts")]
public class SoldProductsDtoExport
{
    [XmlElement("count")]
    public int Count    {get; set;}

    [XmlArray("products")]
    public ProductWithNamePriceDtoExport[] Products { get; set; } = null!;
}

