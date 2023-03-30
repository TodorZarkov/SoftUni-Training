namespace CarDealer.DTOs.Import;

using System.Xml.Serialization;

[XmlType("partId")]
public class PartIdDtoImport
{
    [XmlAttribute("id")]
    public int Id { get; set; }

    public override bool Equals(object? obj)
    {
        var partId = obj as PartIdDtoImport;
        if (partId == null)
        {
            return false;
        }


        return this.Id == partId.Id;
    }

    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }
}
