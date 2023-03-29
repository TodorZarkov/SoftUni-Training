namespace ProductShop.DTOs.Export;

using System.Xml.Serialization;

[XmlType("Category")]
public class CategoriesDtoExport
{
    [XmlElement("name")]
    public string Name { get; set; } = null!;

    [XmlElement("count")]
    public int NumberOfProducts {get; set;}

    [XmlElement("averagePrice")]
    public decimal AvaragePrice {get; set; }

    [XmlElement("totalRevenue")]
    public decimal TotalRevenue { get; set; }
}
