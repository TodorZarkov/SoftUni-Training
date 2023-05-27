namespace EFAspCore.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ProductController : Controller
    {
        public IActionResult All()
        {
            return View();
        }
    }
}
