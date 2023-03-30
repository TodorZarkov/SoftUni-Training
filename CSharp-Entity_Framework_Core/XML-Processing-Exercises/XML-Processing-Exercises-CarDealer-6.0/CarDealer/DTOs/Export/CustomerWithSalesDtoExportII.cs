namespace CarDealer.DTOs.Export;

using System.Xml.Serialization;

[XmlType("customer")]
public class CustomerWithSalesDtoExportII
{
    [XmlAttribute("full-name")]
    public string Name { get; set; } = null!;


    [XmlAttribute("bought-cars")]
    public int CarsBought { get; set; }


    [XmlAttribute("spent-money")]
    public decimal TotalPrice { get; set; }
}