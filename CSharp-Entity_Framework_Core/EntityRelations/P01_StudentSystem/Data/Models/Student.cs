namespace P01_StudentSystem.Data.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Student
{

    public Student()
    {
        StudentsCourses = new HashSet<StudentCourse>();
        Homeworks = new HashSet<Homework>();
        RegisteredOn = DateTime.Now;
    }

    
    public int StudentId { get; set; }

    [MaxLength(200)]
    public string Name { get; set; }


    [Column(TypeName = "CHAR(10)")]
    public string? PhoneNumber { get; set; }

    public DateTime RegisteredOn { get; set; }


    [Column(TypeName = "date")]
    public DateTime? Birthday { get; set; }


    public ICollection<StudentCourse> StudentsCourses { get; set; }

    public ICollection<Homework> Homeworks { get; set; }
}
