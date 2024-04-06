namespace Library.Controllers
{
    using Library.Models.Book;
    using Library.Services.Contracts;
    using static Library.MessageConstants.ValidationMessages;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

    public class BookController : BaseController
    {
        private readonly IBookService bookService;
        private readonly UserManager<IdentityUser> userManager;
        private readonly ICategoryService categoryService;
        private readonly IUserBookService userBookService;
        public BookController(IBookService bookService, UserManager<IdentityUser> userManager, ICategoryService categoryService, IUserBookService userBookService)
        {
            this.bookService = bookService;
            this.userManager = userManager;
            this.categoryService = categoryService;
            this.userBookService = userBookService;
        }


        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await bookService.AllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = userManager.GetUserId(User);
            var model = await bookService.MineAsync(userId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await categoryService.AllForSelectAsync();
            var model = new FormBookDto
            {
                Categories = categories.ToArray()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(FormBookDto model)
        {
            bool existCategory = await categoryService.ExistAsync(model.CategoryId);
            if (!existCategory)
            {
                ModelState.AddModelError(nameof(model.CategoryId), InvalidCategoryId);
            }

            if (!ModelState.IsValid)
            {
                model.Categories = (await categoryService.AllForSelectAsync()).ToArray();
                return View(model);
            }

            var bookId = await bookService.CreateAsync(model);
            return RedirectToAction("All", "Book");
        }


        [HttpPost]
        public async Task<IActionResult> AddToCollection(int id)
        {
            var userId = userManager.GetUserId(User);
            await userBookService.AddToCollectionAsync(id,userId);

            return RedirectToAction("All", "Book");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var userId = userManager.GetUserId(User);
            await userBookService.RemoveFromCollectionAsync(id, userId);

            return RedirectToAction("Mine", "Book");
        }
    }
}
