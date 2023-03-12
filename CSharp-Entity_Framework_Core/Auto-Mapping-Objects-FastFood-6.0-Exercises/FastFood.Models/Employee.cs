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


    [MaxLength(ValidationConstants.GuidMaxLength)]
    public string Id { get; set; }

 
    [StringLength(ValidationConstants.EmployeeNameMaxLength, MinimumLength = 3)]
    public string Name { get; set; } = null!;



    [Range(15, 80)]
    public int Age { get; set; }



    [StringLength(ValidationConstants.EmployeeAddressMaxLength, MinimumLength = 3)]
    public string Address { get; set; } = null!;


    public int PositionId { get; set; }


    public virtual Position Position { get; set; } = null!;


    public virtual ICollection<Order> Orders { get; set; } 
}