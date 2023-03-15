namespace FastFood.Core.Controllers;

using System;
using FastFood.Services.Data;
using Microsoft.AspNetCore.Mvc;

using ViewModels.Employees;

public class EmployeesController : Controller
{
    IEmployeesService employeesService;

    public EmployeesController(IEmployeesService employeesService)
    {
        this.employeesService = employeesService;
    }



    [HttpGet]
    public async Task<IActionResult> Register()
    {
        IEnumerable<RegisterEmployeeViewModel> positions =
            await employeesService.GetAllAvailableAsync();

        return View(positions);
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterEmployeeInputModel model)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Error", "Home");
        }

        await employeesService.CreateAsync(model);

        return RedirectToAction("All");
    }

    public async Task<IActionResult> All()
    {
        IEnumerable<EmployeesAllViewModel> employees =
            await employeesService.GetAllAsync();

        return View(employees.ToList());
    }
}
