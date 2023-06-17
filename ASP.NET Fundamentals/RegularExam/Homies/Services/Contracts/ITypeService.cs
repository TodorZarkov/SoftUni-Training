namespace Homies.Services.Contracts
{
    using Homies.Models.Type;

    public interface ITypeService
    {
        Task<ICollection<TypeSelectViewModel>> GetAllTypesForSelectAsync();

        Task<bool> IsValidType(int typeId);
    }
}
