namespace MiniORM.App.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

internal class EmployeeProject
{
    [Key]
    [ForeignKey(nameof(Employee))]
    public int EmployeeId { get; set; }
    
    [Key]
    [ForeignKey(nameof(Project))]
    public int ProjectId { get; set; }

    public Employee Employee { get; set; }

    public Project Project { get; set; }

}
