namespace SoftUniBazar.Services
{
    using Models.Ad;
    using Data;
    using static Constants.FormatConstants;

    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SoftUniBazar.Services.Contracts;

    public class AdBuyerService : IAdBuyerService
    {
        private readonly BazarDbContext dbContext;

        public AdBuyerService(BazarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(string userId, int adId)
        {
            AdBuyer ab = new AdBuyer
            {
                AdId = adId,
                BuyerId = userId,
            };

            await dbContext.AddAsync(ab);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<AllAdViewModel>> AllByUserAsync(string userId)
        {
            var ads = await dbContext.AdsBuyers
                .AsNoTracking()
                .Where(ab => ab.BuyerId == userId)
                .Select(ab => new AllAdViewModel
                {
                    Id = ab.Ad.Id,
                    Name = ab.Ad.Name,
                    CreatedOn = ab.Ad.CreatedOn.ToString(DateTimeFormat),
                    Category = ab.Ad.Category.Name,
                    ImageUrl = ab.Ad.ImageUrl,
                    Description = ab.Ad.Description,
                    Owner = ab.Ad.Owner.UserName,
                    Price = ab.Ad.Price
                })
                .ToArrayAsync();

            return ads;
        }

        public async Task<bool> ExistAsync(string userId, int adId)
        {
            AdBuyer? ab = await dbContext.AdsBuyers.FindAsync(userId, adId);

            if (ab == null)
            {
                return false;
            }

            return true;
        }

        public async Task RemoveAsync(string userId, int adId)
        {
            AdBuyer? ab = await dbContext.AdsBuyers.FindAsync(userId, adId);

            if (ab == null)
            {
                return;
            }

            dbContext.Remove(ab);
            await dbContext.SaveChangesAsync();
        }


    }
}
