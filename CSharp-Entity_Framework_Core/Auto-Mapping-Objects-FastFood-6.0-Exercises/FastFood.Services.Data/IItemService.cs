namespace FastFood.Services.Data;

using FastFood.Core.ViewModels.Items;

public interface IItemService
{
    Task<IEnumerable<CreateItemViewModel>> GetAllAvailableCategoriesAsync();

    Task CreateAsync(CreateItemInputModel model);

    Task<IEnumerable<ItemsAllViewModels>> GetAllAsync();
}
