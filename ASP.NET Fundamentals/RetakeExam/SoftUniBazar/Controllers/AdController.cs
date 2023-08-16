namespace SoftUniBazar.Controllers
{
	using Microsoft.AspNetCore.Authentication;
	using Microsoft.AspNetCore.Mvc;
    using Microsoft.CodeAnalysis.Completion;
    using SoftUniBazar.Extensions;
    using SoftUniBazar.Models.Ad;
    using SoftUniBazar.Services.Interfaces;

    using static Common.ErrorMassages.Ad;

    public class AdController : BaseController
    {
        private readonly IAdService adService;
        private readonly ICategoryService categoryService;

        public AdController(IAdService adService, ICategoryService categoryService)
        {
            this.adService = adService;
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> All()
        {
            ICollection<AdAllViewModel> model = await adService.AllAsync();

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AdFormModel model = new AdFormModel();
            model.AvailableCategories = await categoryService.AllForSelectAsync();


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AdFormModel model)
        {


            bool validCategoryId = await categoryService.ValidId(model.CategoryId);
            if (!validCategoryId)
            {
                ModelState.AddModelError("CategoryId", string.Format(InvalidCategoryId, model.CategoryId));
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                model.AvailableCategories = await categoryService.AllForSelectAsync();
                return View(model);
            }

            string userId = User.GetId();
            await adService.AddAsync(model, userId);

            return RedirectToAction("All", "Ad");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            AdFormModel model = await adService.GetByIdAsync(id);

            model.AvailableCategories = await categoryService.AllForSelectAsync();


            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(AdFormModel model, int id)
        {
            string userId = User.GetId();
            bool userAuthorized = await adService.UserAuthorizedAsync(userId, id);
            if (!userAuthorized)
            {
                return RedirectToAction("All", "Ad");
            }

            bool validCategoryId = await categoryService.ValidId(model.CategoryId);
            if (!validCategoryId)
            {
                ModelState.AddModelError("CategoryId", string.Format(InvalidCategoryId, model.CategoryId));
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                model.AvailableCategories = await categoryService.AllForSelectAsync();
                return View(model);
            }


            await adService.UpdateAsync(model, id);

            return RedirectToAction("All", "Ad");
        }



        [HttpGet]
        public async Task<IActionResult> AddToCart(int id)
        {
			string userId = User.GetId();
			bool userAuthorized = await adService.UserAuthorizedAsync(userId, id);
			if (!userAuthorized)
			{
				return RedirectToAction("All", "Ad");
			}

            bool isInCart = await adService.IsInCartAsync(id, userId);

            if (isInCart)
            {
                return RedirectToAction("All", "Ad");
            }

            await adService.AddToCartAsync(id , userId);

            return RedirectToAction("Cart", "Ad");
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
			string userId = User.GetId();

            return View();
		}
	}
}
