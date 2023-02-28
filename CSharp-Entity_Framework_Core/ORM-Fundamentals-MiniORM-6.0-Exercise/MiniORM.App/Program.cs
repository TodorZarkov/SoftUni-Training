using MiniORM.App.Data.Entities;
using MiniORM.App.Data;

var connectionString =
            @"Server=.;Database=MiniORM;User Id=SA;Password=barabinecSA!;TrustServerCertificate=true";

var context = new SoftUniDbContextClass(connectionString);

context.Employees.Add(new Employee
{
    FirstName = "Gosho",
    LastName = "Inserted",
    DepartmentId = context.Departments.First().Id,
    IsEmployed = true
});

var employee = context.Employees.Last();
employee.FirstName = "Modified";

context.SaveChanges();




















//namespace MiniORM.App;

//public class Program
//{
//    static void Main(string[] args)
//    {
//        Console.WriteLine("Hello, World!");
//    }
//}