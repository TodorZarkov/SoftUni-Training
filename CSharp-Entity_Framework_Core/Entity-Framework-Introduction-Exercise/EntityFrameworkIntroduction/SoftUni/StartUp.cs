namespace SoftUni;

using Data;
using Microsoft.EntityFrameworkCore;
using SoftUni.Models;
using System.Text;

public class StartUp
{
    private static void Main(string[] args)
    {
        SoftUniContext dbContext = new SoftUniContext();
        //string result = GetEmployeesFullInformation(dbContext);
        //Console.WriteLine(result);

        //string result = GetEmployeesWithSalaryOver50000(dbContext);
        //Console.WriteLine(result);

        //string result = GetEmployeesFromResearchAndDevelopment(dbContext);
        //Console.WriteLine(result);

         string result = AddNewAddressToEmployee(dbContext);
        Console.WriteLine(result);


    }

    //03. Employees Full Information
    public static string GetEmployeesFullInformation(SoftUniContext context)
    {
        var query = context
            .Employees
            .AsNoTracking()
            .OrderBy(e => e.EmployeeId)
            .Select(e => new
            {
                e.FirstName
                ,
                e.LastName
                ,
                e.MiddleName
                ,
                e.JobTitle
                ,
                e.Salary
            });

        //Console.WriteLine(query.ToQueryString());
        //Console.WriteLine(Environment.NewLine);

        var employees = query
            .ToArray();

        StringBuilder sb = new StringBuilder();
        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    //04. Employees with Salary Over 50 000
    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {
        var query = context
            .Employees
            .AsNoTracking()
            .Where(e => e.Salary > 50000)
            .OrderBy(e => e.FirstName)
            .Select(e => new
            {
                e.FirstName
                ,e.Salary
            });

        //Console.WriteLine(query.ToQueryString());

        var employees = query.ToArray();
        StringBuilder sb = new StringBuilder();
        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    //05. Employees from Research and Development
    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
    {
        var queryEmployeesRnD = context
            .Employees
            .AsNoTracking()
            .Where(e => e.Department.Name == "Research and Development")
            .OrderBy(e => e.Salary).ThenByDescending(e => e.FirstName)
            .Select(e => new
            {
                e.FirstName
                ,e.LastName
                ,depName = e.Department.Name
                ,e.Salary
            });

        var employeesRnD = queryEmployeesRnD.ToArray();
        StringBuilder sb = new StringBuilder();
        foreach (var e in employeesRnD)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} from {e.depName} - ${e.Salary:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    //06. Adding a New Address and Updating Employee
    public static string AddNewAddressToEmployee(SoftUniContext context)
    {

        Address addedAddress = new Address
        {
            TownId = 4
            ,AddressText = "Vitoshka 15"
        };

        Employee[] employeesNakov = context
            .Employees
            .Where(e => e.LastName == "Nakov")
            .ToArray();

        foreach (Employee e in employeesNakov)
        {
            e.Address = addedAddress;
        }

        context.SaveChanges();

        var employeesAddress = context
            .Employees
            .AsNoTracking()
            .OrderByDescending(e => e.AddressId)
            .Select(e => new
            {
                adress = e.Address.AddressText
            })
            .Take(10)
            .ToArray();

        StringBuilder sb = new StringBuilder();
        foreach (var a in employeesAddress)
        {
            sb.AppendLine(a.adress);
        }

        return sb.ToString().TrimEnd();
    }

    //07. Employees and Projects 


}
