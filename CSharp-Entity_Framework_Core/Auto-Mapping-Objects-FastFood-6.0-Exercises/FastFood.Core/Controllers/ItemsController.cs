namespace FastFood.Core.Controllers
{
    using System;
    using AutoMapper;
    using FastFood.Data;
    using FastFood.Models;
    using FastFood.Services.Data;
    using Microsoft.AspNetCore.Mvc;

    using ViewModels.Items;

    public class ItemsController : Controller
    {
        private readonly IItemService itemService;
        private readonly IMapper mapper;
        private readonly FastFoodContext context;

        public ItemsController(IItemService itemService, IMapper mapper, FastFoodContext context)
        {
            this.itemService = itemService;
            this.mapper = mapper;
            this.context = context;
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
            IEnumerable<Item> createdItems = 
        }

        public IActionResult All()
        {
            throw new NotImplementedException();
        }
    }
}
