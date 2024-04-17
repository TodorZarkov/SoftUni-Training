namespace SoftUniBazar.Services
{
    using Data;
    using Models.Ad;

    using static Constants.FormatConstants;

    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SoftUniBazar.Services.Contracts;

    public class AdService : IAdService
    {
        private readonly BazarDbContext dbContext;

        public AdService(BazarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<AllAdViewModel>> AllAsync()
        {
            var ads = await dbContext.Ads
                .AsNoTracking()
                .Select(a => new AllAdViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    CreatedOn = a.CreatedOn.ToString(DateTimeFormat),
                    Category = a.Category.Name,
                    Owner = a.Owner.UserName,
                    Description = a.Description,
                    ImageUrl = a.ImageUrl,
                    Price = a.Price
                })
                .ToArrayAsync();

            return ads;
        }

        public async Task<int> CreateAsync(FormAdViewModel model, string userId)
        {
            Data.Ad ad = new Ad
            {
                CreatedOn = DateTime.Now,
                Description = model.Description,
                Name = model.Name,
                OwnerId = userId,
                CategoryId = model.CategoryId,
                ImageUrl = model.ImageUrl,
                Price = model.Price
            };

            await dbContext.AddAsync(ad);
            await dbContext.SaveChangesAsync();

            return ad.Id;
        }

        public async Task EditAsync(FormAdViewModel model, int adId)
        {
            Data.Ad ad = await dbContext.Ads.FindAsync(adId) ?? throw new ArgumentNullException("The Ad Id doesn't exist.");
            ad.Description = model.Description;
            ad.Name = model.Name;
            ad.CategoryId = model.CategoryId;
            ad.Price = model.Price;
            ad.ImageUrl = model.ImageUrl;

            await dbContext.SaveChangesAsync();
        }

       

        public async Task<FormAdViewModel> GetForEditByIdAsync(int adId)
        {
            FormAdViewModel model = await dbContext.Ads
                .AsNoTracking()
                .Where(a => a.Id == adId)
                .Select(a => new FormAdViewModel
                {
                    Description = a.Description,
                    Name = a.Name,
                    CategoryId = a.CategoryId,
                    Price = a.Price,
                    ImageUrl = a.ImageUrl
                })
                .FirstAsync();

            return model;
        }

        public async Task<bool> IsOwnerAsync(string userId, int adId)
        {
            bool result = await dbContext.Ads
                .AsNoTracking()
                .AnyAsync(a => a.Id == adId && a.OwnerId == userId);

            return result;
        }
    }
}
