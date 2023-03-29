namespace CarDealer.DTOs.Import;

using System.Xml.Serialization;

[XmlType("Supplier")]
public class SupplierDtoImport
{
    [XmlElement("name")]
    public string Name { get; set; } = null!;

    [XmlElement("isImporter")]
    public bool IsImporter { get; set; }
}
