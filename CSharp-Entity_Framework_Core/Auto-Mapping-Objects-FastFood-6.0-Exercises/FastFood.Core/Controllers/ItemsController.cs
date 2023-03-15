namespace FastFood.Core.Controllers
{
    using System;
    using AutoMapper;
    using FastFood.Data;
    using FastFood.Models;
    using FastFood.Services.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using ViewModels.Items;

    public class ItemsController : Controller
    {
        private readonly IItemService itemService;

        public ItemsController(IItemService itemService)
        {
            this.itemService = itemService;
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            IEnumerable<CreateItemViewModel> availableCategories =
                await itemService.GetAllAvailableCategoriesAsync();

            return View(availableCategories.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateItemInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            await itemService.CreateAsync(model);

            return RedirectToAction("All");
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<ItemsAllViewModels> items =
                await itemService.GetAllAsync();

            return View(items.ToList());
        }
    }
}
