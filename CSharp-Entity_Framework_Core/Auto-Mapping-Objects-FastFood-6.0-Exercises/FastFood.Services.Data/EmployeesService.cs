namespace FastFood.Services.Data;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using FastFood.Core.ViewModels.Employees;
using FastFood.Data;
using FastFood.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class EmployeesService : IEmployeesService
{
    private readonly IMapper mapper;
    private readonly FastFoodContext context;

    public EmployeesService(IMapper mapper, FastFoodContext context)
    {
        this.mapper = mapper;
        this.context = context;
    }

    public async Task CreateAsync(RegisterEmployeeInputModel model)
    {
        Employee employee =
            mapper.Map<Employee>(model);
        await context.Employees.AddAsync(employee);

        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<EmployeesAllViewModel>> GetAllAsync()
        => await context.Employees
        .ProjectTo<EmployeesAllViewModel>(mapper.ConfigurationProvider).ToArrayAsync();

    public async Task<IEnumerable<RegisterEmployeeViewModel>> GetAllAvailableAsync()
        => await context.Positions
        .ProjectTo<RegisterEmployeeViewModel>(mapper.ConfigurationProvider).ToArrayAsync();


}
