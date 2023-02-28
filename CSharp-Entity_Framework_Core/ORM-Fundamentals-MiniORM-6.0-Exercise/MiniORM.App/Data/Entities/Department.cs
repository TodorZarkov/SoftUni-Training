namespace MiniORM.App.Data.Entities;

using System.ComponentModel.DataAnnotations;

public class Department
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    public ICollection<Employee> Employees { get; }
}
