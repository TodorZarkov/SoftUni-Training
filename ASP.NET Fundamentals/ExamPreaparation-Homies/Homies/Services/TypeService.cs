namespace Homies.Services
{
	using Homies.Data;
	using Homies.Models.Type;
	using Homies.Services.Contracts;
	using Microsoft.EntityFrameworkCore;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public class TypeService : ITypeService
	{
		private readonly HomiesDbContext dbContext;

		public TypeService(HomiesDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<ICollection<TypeViewModel>> AllAsync()
		{
			var types = await dbContext.Types
				.AsNoTracking()
				.Select(t => new TypeViewModel
				{
					Id = t.Id,
					Name = t.Name
				})
				.ToArrayAsync();

			return types;
		}

		public async Task<bool> ExistAsync(int typeId)
		{
			Data.Type? type = await dbContext.Types.FindAsync(typeId);

			if (type == null)
			{
				return false;
			}

			return true;
		}
	}
}
