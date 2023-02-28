namespace MiniORM.App.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Employee
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }

    [StringLength(50)]
    public string MiddleName { get; set; }

    [Required]
    [StringLength(50)]
    public string LastName { get; set; }

    [Required]
    public bool IsEmployed { get; set; }

    [ForeignKey(nameof(Department))]
    public int DepartmentId { get; set; }

    public Department Department { get; set; }

    public ICollection<EmployeeProject> EmployeeProjects { get; set; }

}
