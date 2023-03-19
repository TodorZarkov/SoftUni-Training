namespace CarDealer.DTOs.Import;

using CarDealer.Models;

public class PartDtoImport
{
    public string Name { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public int SupplierId { get; set; }
}
