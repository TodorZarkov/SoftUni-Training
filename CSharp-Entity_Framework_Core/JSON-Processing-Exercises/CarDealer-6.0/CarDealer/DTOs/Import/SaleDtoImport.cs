namespace CarDealer.DTOs.Import;

using CarDealer.Models;

public class SaleDtoImport
{
    public int CarId { get; set; }

    public int CustomerId { get; set; }

    public decimal Discount { get; set; }
}
