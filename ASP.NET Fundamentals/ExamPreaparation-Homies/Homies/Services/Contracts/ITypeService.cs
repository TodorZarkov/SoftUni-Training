namespace Homies.Services.Contracts
{
	using Homies.Models.Type;

	public interface ITypeService
	{
		Task<ICollection<TypeViewModel>> AllAsync();

		Task<bool> ExistAsync(int typeId);
	}
}
