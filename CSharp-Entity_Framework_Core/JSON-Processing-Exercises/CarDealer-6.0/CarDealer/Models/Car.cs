namespace CarDealer.Models;

public class Car
{
    public int Id { get; set; }

    public string Make { get; set; }

    public string Model { get; set; }

    public long TraveledDistance { get; set; }

    public ICollection<PartCar> PartCars { get; set; }
}
