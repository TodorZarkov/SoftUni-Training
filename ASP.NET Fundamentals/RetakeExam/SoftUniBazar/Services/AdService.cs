namespace SoftUniBazar.Services
{
	using Microsoft.EntityFrameworkCore;
	using SoftUniBazar.Common.Services.Interfaces;
	using SoftUniBazar.Data;
	using SoftUniBazar.Models.Ad;
	using SoftUniBazar.Services.Interfaces;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using static Common.FormatConstants.DateAndTime;

	public class AdService : IAdService
	{
		private readonly BazarDbContext dbContext;
		private readonly IDateTimeProvider dateTimeProvider;

		public AdService(BazarDbContext dbContext, IDateTimeProvider dateTimeProvider)
		{
			this.dbContext = dbContext;
			this.dateTimeProvider = dateTimeProvider;
		}



		public async Task<ICollection<AdAllViewModel>> AllAsync()
		{
			ICollection<AdAllViewModel> ads = await dbContext.Ads
				.AsNoTracking()
				.Select(a => new AdAllViewModel
				{
					Name = a.Name,
					Category = a.Category.Name,
					Description = a.Description,
					CreatedOn = a.CreatedOn.ToString(CreatedOnDateTimeFormat),
					Id = a.Id,
					ImageUrl = a.ImageUrl,
					Price = a.Price.ToString("N2"),
					Seller = a.Owner.Email
				})
				.ToArrayAsync();

			return ads;
		}
		public async Task<AdFormModel> GetByIdAsync(int id)
		{
			AdFormModel model = await dbContext.Ads
				.AsNoTracking()
				.Where(a => a.Id == id)
				.Select(a => new AdFormModel()
				{
					Description = a.Description,
					CategoryId = a.CategoryId,
					ImageUrl = a.ImageUrl,
					Name = a.Name,
					Price = a.Price
				})
				.SingleAsync();

			return model;
		}


		public async Task AddAsync(AdFormModel model, string userId)
		{
            Data.Models.Ad ad = new Data.Models.Ad()
			{
				Description = model.Description,
				CategoryId = model.CategoryId,
				CreatedOn = dateTimeProvider.GetCurrentDateTime(),
				ImageUrl = model.ImageUrl,
				Name = model.Name,
				OwnerId = userId,
				Price = model.Price

			};

			

			dbContext.Ads.Add(ad);

			await dbContext.SaveChangesAsync();

		}
		public async Task UpdateAsync(AdFormModel model, int id)
		{
            Data.Models.Ad ad = await dbContext.Ads.
				Where(a => a.Id == id)
				.SingleAsync();

			ad.Description = model.Description;
			ad.CategoryId = model.CategoryId;
			ad.CreatedOn = dateTimeProvider.GetCurrentDateTime();
			ad.ImageUrl = model.ImageUrl;
			ad.Name = model.Name;
			ad.Price = model.Price;

			await dbContext.SaveChangesAsync();
		}


		public async Task<bool> UserAuthorizedAsync(string userId, int id)
		{
			bool result = await dbContext.Ads
				.AnyAsync(a => a.OwnerId == userId && a.Id == id);


			return result;
		}


		public async Task<bool> IsInCartAsync(int id, string userId)
		{
			bool result = await dbContext.AdsBuyers
				.AnyAsync(ab => ab.BuyerId == userId && ab.AdId ==id);

			return result;
		}
		public async Task AddToCartAsync(int id , string userId)
		{
			Data.Models.AdBuyer adBuyer = new Data.Models.AdBuyer()
			{
				BuyerId = userId,
				AdId = id
			};
			dbContext.AdsBuyers.Add(adBuyer);

			await dbContext.SaveChangesAsync();
		}
	}
}
