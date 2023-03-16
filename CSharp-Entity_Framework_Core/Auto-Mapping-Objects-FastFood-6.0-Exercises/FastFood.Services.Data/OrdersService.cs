namespace FastFood.Services.Data;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using FastFood.Core.ViewModels.Orders;
using FastFood.Data;
using FastFood.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class OrdersService : IOrdersService
{
    IMapper mapper;
    FastFoodContext context;

    public OrdersService(IMapper mapper, FastFoodContext context)
    {
        this.mapper = mapper;
        this.context = context;
    }

    public async Task CreateAsync(CreateOrderInputModel model)
    {
        Order? order = await GetOrder(model);

        if (order == null)
        {
            Item?  item = await GetItem(model);
            if (item == null)
            {
                return;
            }

            order = new Order
            {
                Customer  = model.Customer,
                DateTime = DateTime.Now,
                Type = Models.Enums.OrderType.ForHere,
                EmployeeId = model.EmployeeId
            };
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();

            OrderItem orderItem = new OrderItem
            {
                OrderId = order.Id,
                ItemId = item.Id,
                Quantity = model.Quantity
            };
            await context.OrderItems.AddAsync(orderItem);
            await context.SaveChangesAsync();
        }
        else
        {
            Item? item = await GetItem(model);
            if (item == null)
            {
                return;
            }

            OrderItem orderItem = new OrderItem
            {
                OrderId = order.Id,
                ItemId = item.Id,
                Quantity = model.Quantity
            };
            await context.OrderItems.AddAsync(orderItem);
            await context.SaveChangesAsync();
        }
    }

    private async Task<Order?> GetOrder(CreateOrderInputModel model)
    {
        return await context.Orders.FirstOrDefaultAsync(o => o.Customer == model.Customer &&
                                                    o.EmployeeId == model.EmployeeId);
    }

    private async Task<Item?> GetItem(CreateOrderInputModel model)
    {
        return await context.Items.FirstOrDefaultAsync(i => i.Id == model.ItemId);
    }

    public async Task<IEnumerable<OrderAllViewModel>> GetAllAsync()
        => await context.Orders
        .ProjectTo<OrderAllViewModel>(mapper.ConfigurationProvider).ToListAsync();

    public async Task<CreateOrderViewModel> GetAvailableAsync()
    {
        List<Tuple<string,string?>> items = await context.Items.Select(i => new Tuple<string, string>(i.Id, i.Name)).ToListAsync();
        List<Tuple<string, string?>> employees = await context.Employees.Select(e => new Tuple<string, string>(e.Id, e.Name)).ToListAsync();
       

        CreateOrderViewModel orderViewModel = new CreateOrderViewModel
        {
            Items = items,
            Employees = employees,
        };

        return orderViewModel;
    }



}
