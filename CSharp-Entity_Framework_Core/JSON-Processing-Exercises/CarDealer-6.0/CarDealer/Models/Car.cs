namespace CarDealer.Models;

using System.ComponentModel.DataAnnotations.Schema;

public class Car
{
    public int Id { get; set; }

    public string Make { get; set; }

    public string Model { get; set; }

    public long TraveledDistance { get; set; }

    public ICollection<PartCar> PartCars { get; set; }

    [NotMapped]
    public decimal Price => PartCars.Sum(pc => pc.Part.Price);
}
