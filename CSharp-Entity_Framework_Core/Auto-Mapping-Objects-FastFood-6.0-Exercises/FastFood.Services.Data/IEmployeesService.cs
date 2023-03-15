namespace FastFood.Services.Data;

using FastFood.Core.ViewModels.Employees;

public interface IEmployeesService
{
    Task<IEnumerable<RegisterEmployeeViewModel>> GetAllAvailableAsync();

    Task CreateAsync(RegisterEmployeeInputModel model);

    Task<IEnumerable<EmployeesAllViewModel>> GetAllAsync();
}
