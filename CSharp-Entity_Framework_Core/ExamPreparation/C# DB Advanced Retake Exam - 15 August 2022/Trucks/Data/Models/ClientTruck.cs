namespace Trucks.Data.Models;

using System.ComponentModel.DataAnnotations;

public class ClientTruck
{
    [Required]
    public int ClientId { get; set; }
    public Client Client { get; set; } = null!;


    [Required]
    public int TruckId { get; set; }
    public Truck Truck { get; set; } = null!;
}
