using Library.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var allBooks = await bookService.GetAllBooksAsync();

            return View(allBooks);
        }
    }
}
