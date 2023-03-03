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

        //string result = AddNewAddressToEmployee(dbContext);
        //Console.WriteLine(result);

        //string result = GetEmployeesInPeriod(dbContext);
        //Console.WriteLine(result);

        //string result = GetAddressesByTown(dbContext);
        //Console.WriteLine(result);

        //string result = GetEmployee147(dbContext);
        //Console.WriteLine(result);

        //string result = GetDepartmentsWithMoreThan5Employees(dbContext);
        //Console.WriteLine(result);

        //string result = GetLatestProjects(dbContext);
        //Console.WriteLine(result);

        //string result = IncreaseSalaries(dbContext);
        //Console.WriteLine(result);

        //string result = GetEmployeesByFirstNameStartingWithSa(dbContext);
        //Console.WriteLine(result);

        string result = DeleteProjectById(dbContext);
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
            .Select(e =>  e.Address.AddressText)
            .Take(10)
            .ToArray();

        return string.Join(Environment.NewLine, employeesAddress);
    }

    //07. Employees and Projects 
    public static string GetEmployeesInPeriod(SoftUniContext context)
    {
        var employees = context
            .Employees
            .AsNoTracking()
            //.Where(e => e.EmployeesProjects.Any(ep =>
            //    ep.Project.StartDate.Year >= 2001 &&
            //    ep.Project.StartDate.Year <= 2003
            //))
            .Select(e => new
            {
                e.FirstName
                , e.LastName
                , ManagerFirstName = e.Manager.FirstName
                , ManagerLastName = e.Manager.LastName
                , Projects = e
                    .EmployeesProjects
                    .Where(ep => ep.Project.StartDate.Year >= 2001 &&
                                 ep.Project.StartDate.Year <= 2003)
                    .Select(ep => new
                    {
                        ep.Project.Name
                        , StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt")
                        , EndDate = ep.Project.EndDate.HasValue?
                            ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt"):
                            "not finished"
                    })
                    .ToArray()
            })
            .Take(10)
            .ToArray();

        StringBuilder sb = new StringBuilder();
        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");
            foreach (var project in employee.Projects)
            {
                sb.AppendLine($"--{project.Name} - {project.StartDate} - {project.EndDate}");
            }
        }

        return sb.ToString().TrimEnd();
    }

    //08. Addresses by Town
    public static string GetAddressesByTown(SoftUniContext context)
    {
        var addresses = context
            .Addresses
            .OrderByDescending(a => a.Employees.Count)
            .ThenBy(a => a.Town.Name)
            .ThenBy(a => a.AddressText)
            .Select(a => new
            {
                a.AddressText
                ,TownName = a.Town.Name
                ,EmployeesCount = a.Employees.Count
            })
            .Take(10)
            .ToArray();

        StringBuilder sb = new StringBuilder();
        foreach (var a in addresses)
        {
            sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeesCount} employees");
        }

        return sb.ToString().TrimEnd();
    }

    //09. Employee 147 
    public static string GetEmployee147(SoftUniContext context)
    {
        var employee = context
            .Employees
            .Where(e => e.EmployeeId == 147)
            .Select(e => new
            {
                e.FirstName
                ,
                e.LastName
                ,
                e.JobTitle
                ,
                Projects =
                    e
                    .EmployeesProjects
                    .Select(ep => ep.Project.Name)
                    .OrderBy(n => n)
                    .ToArray()
            })
            .FirstOrDefault();

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
        sb.Append(string.Join(Environment.NewLine,employee.Projects));

        return sb.ToString().Trim();
    }

    //10. Departments with More Than 5 Employees
    public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
    {
        var departments = context
            .Departments
            .Where(d => d.Employees.Count > 5)
            .OrderBy(d => d.Employees.Count)
            .OrderBy(d => d.Name)//to check alphabetically
            .Select(d => new
            {
                d.Name
                ,ManagerFirstName = d.Manager.FirstName
                ,ManagerLastName = d.Manager.LastName
                ,Employees = d.Employees
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .Select(e => new
                    {
                         e.FirstName
                        ,e.LastName
                        ,e.JobTitle
                    })
                    .ToArray()
            })
            .ToArray();

        StringBuilder sb = new StringBuilder();
        foreach (var d in departments)
        {
            sb.AppendLine($"{d.Name} – {d.ManagerFirstName} {d.ManagerLastName}");
            foreach (var e in d.Employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
            }
        }
        return sb.ToString().Trim();
    }

    //11. Find Latest 10 Projects
    public static string GetLatestProjects(SoftUniContext context)
    {

        var projects = context
            .Projects
            .OrderByDescending(p => p.StartDate)
            .Select(p => new
            {
                p.Name
                ,
                p.Description
                ,
                StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt")
            })
            .Take(10)
            .OrderBy(p => p.Name)
            .ThenBy(p => p.Name.Length)
            .ToList();

        StringBuilder sb = new StringBuilder();
        foreach (var p in projects)
        {
            sb.AppendLine(p.Name);
            sb.AppendLine(p.Description);
            sb.AppendLine(p.StartDate);
        }

        return sb.ToString().Trim();
    }

    //12. Increase Salaries
    public static string IncreaseSalaries(SoftUniContext context)
    {
        var toIncreaseSalary = context
            .Employees
            .Where(e => e.Department.Name == "Engineering" ||
                        e.Department.Name == "Tool Design" ||
                        e.Department.Name == "Marketing" ||
                        e.Department.Name == "Information Services");

        foreach (var e in toIncreaseSalary)
        {
            e.Salary *= 1.12m;
        }

        context.SaveChanges();

        var employees = context
            .Employees
            .AsNoTracking()
            .Where(e => e.Department.Name == "Engineering" ||
                        e.Department.Name == "Tool Design" ||
                        e.Department.Name == "Marketing" ||
                        e.Department.Name == "Information Services")
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .Select(e => new
            {
                 e.FirstName
                ,e.LastName
                ,e.Salary
            })
            .ToArray();

        StringBuilder sb = new StringBuilder();
        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
        }

        return sb.ToString().Trim();
    }

    //13. Find Employees by First Name Starting With Sa
    public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
    {
        var employees = context
            .Employees
            .AsNoTracking()
            .Where(e => e.FirstName.ToLower().StartsWith("sa"))
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .Select(e => new
            {
                 e.FirstName
                ,e.LastName
                ,e.JobTitle
                ,e.Salary
            })
            .ToArray();

        StringBuilder sb = new StringBuilder();
        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
        }

        return sb.ToString().Trim();
    }

    //14. Delete Project by Id
    public static string DeleteProjectById(SoftUniContext context)
    {
        var project = context.Projects.Find(2);

        context.EmployeesProjects.RemoveRange(
            context
            .EmployeesProjects
            .Where(ep => ep.ProjectId == 2));

        context.Projects.Remove(project);

        context.SaveChanges();

        var projects = context
            .Projects
            .Select(p => p.Name)
            .Take(10)
            .ToArray();
        return string.Join(Environment.NewLine, projects);
    }
}
