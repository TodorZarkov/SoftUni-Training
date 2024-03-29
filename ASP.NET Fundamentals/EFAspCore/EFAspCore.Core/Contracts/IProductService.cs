﻿namespace EFAspCore.Core.Contracts
{
	using EFAspCore.Core.Models;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public interface IProductService
	{
		Task<List<ProductViewModel>> GetProductsAsync();

		Task AddProductAsync(ProductFormModel model);

		Task DeleteProductAsync(int id);

		Task<ProductViewModel> GetProductAsync(int id);
		Task UpdateProductAsync(ProductViewModel model);
	}
}
