namespace CarDealer.DTOs.Import;

using CarDealer.Models;

public class CarDtoImport
{
    public string Make { get; set; }

    public string Model { get; set; }

    public int TraveledDistance { get; set; }

    public HashSet<int> PartsId { get; set; }
}
