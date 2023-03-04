namespace P01_StudentSystem.Data;

using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

public class StudentSystemContext : DbContext
{
    public StudentSystemContext()
    {
    }

    public StudentSystemContext(DbContextOptions<StudentSystemContext> options) : base(options)
    {
    }


    public virtual DbSet<Student> Students { get; set; } = null!;

    public virtual DbSet<Course> Courses { get; set; } = null!;

    public virtual DbSet<Resource> Resources { get; set; } = null!;

    public virtual DbSet<Homework> Homeworks { get; set; } = null!;

    public virtual DbSet<StudentCourse> StudentsCourses { get; set; } = null!;



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
		if (!optionsBuilder.IsConfigured)
		{
            optionsBuilder.UseSqlServer(Config.SqlConnectionString);
        }
    }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentCourse>()
            .HasKey(x => new { x.StudentId, x.CourseId });
    }
}
