namespace ProductShop.Dto.Export;

public class ProductDtoExport
{
    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string Seller { get; set; } = null!;
}