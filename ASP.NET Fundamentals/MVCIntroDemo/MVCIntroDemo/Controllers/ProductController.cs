namespace MVCIntroDemo.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Net.Http.Headers;
	using MVCIntroDemo.ViewModels.Product;
	using Newtonsoft.Json;
	using System.Text;
	using System.Text.Json;
	using static Seeding.ProductsData;

	public class ProductController : Controller
	{
		public IActionResult All(string keyword)
		{
			if (string.IsNullOrWhiteSpace(keyword))
			{
				return View(Products);
			}
			IEnumerable<ProductViewModel> filteredProducts = Products
				.Where(p => p.Name.ToLower().Contains(keyword.ToLower()))
				.ToArray();

			return View(filteredProducts);
		}

		[ActionName("Details")]
		public IActionResult ById(string id)
		{
			ProductViewModel? product = Products
				.FirstOrDefault(p => p.Id.ToString() == id);
			if (product == null)
			{
				return RedirectToAction("All");
			}
			return View(product);
		}

		public IActionResult AllAsJson()
		{
			//string jsonText = JsonConvert.SerializeObject(Products, Formatting.Indented);

			return Json(Products, new JsonSerializerOptions()
			{
				WriteIndented = true
			});
		}

		public IActionResult AllAsText()
		{
			StringBuilder sb = new StringBuilder();
			foreach (ProductViewModel product in Products)
			{
				sb.AppendLine($"Product {product.Id}: {product.Name} - {product.Price} $.");
			}

			return Content(sb.ToString().TrimEnd());
		}

		public IActionResult DownloadProductInfo()
		{
			StringBuilder sb = new StringBuilder();
			foreach (ProductViewModel product in Products)
			{
				sb.AppendLine($"Product {product.Id}: {product.Name} - {product.Price:f2} $.");
			}

			Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=products.txt");

			return File(Encoding.UTF8.GetBytes(sb.ToString().TrimEnd()), "text/plain");
		}
	}
}
