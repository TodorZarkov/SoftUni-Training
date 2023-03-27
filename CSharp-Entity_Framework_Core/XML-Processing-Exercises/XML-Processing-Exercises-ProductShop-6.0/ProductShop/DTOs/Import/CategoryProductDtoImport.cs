namespace ProductShop.DTOs.Import;

using System.Xml.Serialization;

[XmlType("CategoryProduct")]
public class CategoryProductDtoImport
{
    public int CategoryId { get; set; }

    public int ProductId { get; set; }
}
