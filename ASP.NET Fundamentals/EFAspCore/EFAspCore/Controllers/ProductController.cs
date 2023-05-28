namespace EFAspCore.Controllers
{
    using EFAspCore.Core.Contracts;
    using EFAspCore.Core.Models;
    using Microsoft.AspNetCore.Mvc;

    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            //var model = await productService.GetProductsAsync();

            //return View("All", model);
            return RedirectToAction(nameof(All));
		}
        public async Task<IActionResult> All()
        {
            var model = await productService.GetProductsAsync();

            return View(model);
        }

        public IActionResult Add()
        {
            var model = new ProductFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await productService.AddProductAsync(model);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await productService.DeleteProductAsync(id);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Edit(int id)
        {
            ProductViewModel model = await productService.GetProductAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel model)
        {
            await productService.UpdateProductAsync(model);

            return RedirectToAction(nameof(All));
        }
    }
}
