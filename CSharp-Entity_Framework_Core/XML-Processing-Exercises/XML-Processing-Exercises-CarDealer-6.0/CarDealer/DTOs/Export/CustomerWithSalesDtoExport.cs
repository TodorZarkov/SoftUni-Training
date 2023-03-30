namespace CarDealer.DTOs.Export;

using System.Xml.Serialization;

[XmlType("customer")]
public class CustomerWithSalesDtoExport
{
    [XmlAttribute("full-name")]
    public string FullName { get; set; } = null!;


    [XmlAttribute("bought-cars")]
    public int CarsBought { get; set; }


    [XmlAttribute("spent-money")]
    public string TotalPrice { get; set; } = null!;
}
