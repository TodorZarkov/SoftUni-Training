using Library.Extensions;
using Library.Services.Contracts;
using Library.ViewModels.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        private readonly ICategoryService categoryService;

        public BookController(IBookService bookService, ICategoryService categoryService)
        {
            this.bookService = bookService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var allBooks = await bookService.GetAllBooksAsync();

            return View(allBooks);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            FormBookViewModel bookViewModel = new FormBookViewModel();
            bookViewModel.Categories = await categoryService.GetAllCategoriesAsync();

            return View(bookViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(FormBookViewModel bookViewModel)
        {
            bool isCategoryValid = await categoryService.HasCategoryAsync(bookViewModel.CategoryId);
            if (!isCategoryValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid Category Id");
                bookViewModel.Categories = await categoryService.GetAllCategoriesAsync();
                return View(bookViewModel);
            }
            if (!ModelState.IsValid)
            {
                bookViewModel.Categories = await categoryService.GetAllCategoriesAsync();
                return View(bookViewModel);
            }

            await bookService.AddAsync(bookViewModel);

            return RedirectToAction("All", "Book");
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int id)
        {
            string userId = User.GetId();
            try
            {
                await bookService.AddToUserAsync(id, userId);
                return RedirectToAction("All", "Book");
            }
            catch (Exception)
            {
                return RedirectToAction("All", "Book");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var booksViewModel = await bookService
                .GetAllBooksAsync(User.GetId());

            return View(booksViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            await bookService.RemoveFromUserAsync(id, User.GetId());

            return RedirectToAction("Mine", "Book");
        }
    }
}
