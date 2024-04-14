namespace SoftUniBazar.Controllers
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;

	using Services.Contracts;
	using SoftUniBazar.Models.Ad;

	using static Constants.MessageConstants;

	public class AdController : BaseController
	{
		private readonly IAdService adService;
		private readonly ICategoryService categoryService;
		private readonly IAdBuyerService adBuyerService;
		private readonly UserManager<IdentityUser> userManager;

		public AdController(IAdService adService, ICategoryService categoryService, IAdBuyerService adBuyerService, UserManager<IdentityUser> userManager)
		{
			this.adService = adService;
			this.categoryService = categoryService;
			this.adBuyerService = adBuyerService;
			this.userManager = userManager;
		}

		[HttpGet]
		public async Task<IActionResult> All()
		{
			var model = await adService.AllAsync();

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var model = new FormAdViewModel
			{
				Categories = (await categoryService.AllAsync()).ToArray()
			};

			return View(model);
		}


		[HttpPost]
		public async Task<IActionResult> Add(FormAdViewModel model)
		{
			if (!ModelState.IsValid)
			{
				model.Categories = (await categoryService.AllAsync()).ToArray();
				return View(model);
			}
			bool isValidCategoryId = await categoryService.ExistAsync(model.CategoryId);
			if (!isValidCategoryId)
			{
				ModelState.AddModelError(nameof(model.CategoryId), InvalidCategoryId);
				model.Categories = (await categoryService.AllAsync()).ToArray();
				return View(model);
			}

			

			int adId = await adService.CreateAsync(model, userManager.GetUserId(User));

			return RedirectToAction("All", "Ad");
		}


		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			string userId = userManager.GetUserId(User);
			bool canEdit = await adService.IsOwnerAsync(userId, id);
			if (!canEdit)
			{
				return RedirectToAction("All", "Ad");
			}

			FormAdViewModel model = await adService.GetForEditByIdAsync(id);
			model.Categories = (await categoryService.AllAsync()).ToArray();
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(FormAdViewModel model, int id)
		{
			string userId = userManager.GetUserId(User);
			bool canEdit = await adService.IsOwnerAsync(userId, id);
			if (!canEdit)
			{
				return RedirectToAction("All", "Ad");
			}

			if (!ModelState.IsValid)
			{
				model.Categories = (await categoryService.AllAsync()).ToArray();
				return View(model);
			}
			bool isValidCategoryId = await categoryService.ExistAsync(model.CategoryId);
			if (!isValidCategoryId)
			{
				ModelState.AddModelError(nameof(model.CategoryId), InvalidCategoryId);
				model.Categories = (await categoryService.AllAsync()).ToArray();
				return View(model);
			}


			await adService.EditAsync(model, id);

			return RedirectToAction("All", "Ad");

		}

	}
}
