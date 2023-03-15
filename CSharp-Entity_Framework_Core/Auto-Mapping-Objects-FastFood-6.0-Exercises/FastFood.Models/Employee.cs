namespace FastFood.Models;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Common.EntityConfiguration;

public class Employee
{
    public Employee()
    {
        Orders = new HashSet<Order>();
        Id = Guid.NewGuid().ToString();
    }


    [MaxLength(EntitiesValidation.GuidMaxLength)]
    public string Id { get; set; }


    [MaxLength(EntitiesValidation.EmployeeNameMaxLength)]
    public string Name { get; set; } = null!;


    public int Age { get; set; }


    [MaxLength(EntitiesValidation.EmployeeAddressMaxLength)]
    public string Address { get; set; } = null!;


    public int PositionId { get; set; }


    public virtual Position Position { get; set; } = null!;


    public virtual ICollection<Order> Orders { get; set; } 
}