namespace FastFood.Core.Controllers
{
    using System;
    using System.Linq;
    using AutoMapper;
    using Data;
    using FastFood.Services.Data;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Orders;

    public class OrdersController : Controller
    {
        IOrdersService ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewOrder = await ordersService.GetAvailableAsync();

            return View(viewOrder);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            await ordersService.CreateAsync(model);

            return RedirectToAction("All");
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<OrderAllViewModel> ordersViewModels =
                await ordersService.GetAllAsync();

            return View(ordersViewModels.ToList());
        }
    }
}
