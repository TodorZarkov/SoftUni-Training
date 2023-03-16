namespace FastFood.Services.Data;

using FastFood.Core.ViewModels.Orders;

public interface IOrdersService 
{
    Task<CreateOrderViewModel> GetAvailableAsync();

    Task CreateAsync(CreateOrderInputModel model);

    Task<IEnumerable<OrderAllViewModel>> GetAllAsync();
}
