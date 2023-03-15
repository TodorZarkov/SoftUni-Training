namespace FastFood.Core.Controllers;

using FastFood.Services.Data;
using Microsoft.AspNetCore.Mvc;

using ViewModels.Categories;

public class CategoriesController : Controller
{
    private readonly ICategoryService categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        this.categoryService = categoryService;
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryInputModel model)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Error", "Home");
        }

        await categoryService.CreateAsync(model);

        return RedirectToAction("All");
    }

    public async Task<IActionResult> All()
    {
        IEnumerable<CategoryAllViewModel> categories =
            await categoryService.GetAllAsync();

        return View(categories.ToList());
    }
}
