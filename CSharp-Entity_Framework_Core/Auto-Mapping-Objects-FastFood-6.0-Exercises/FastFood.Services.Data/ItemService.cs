namespace FastFood.Services.Data;

using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using FastFood.Core.ViewModels.Items;
using FastFood.Data;


public class ItemService : IItemService
{
    private readonly IMapper mapper;
    private readonly FastFoodContext context;

    public ItemService(IMapper mapper, FastFoodContext context)
    {
        this.mapper = mapper;
        this.context = context;
    }

    public async Task<IEnumerable<CreateItemViewModel>> GetAllAvailableCategoriesAsync()
        => await context.Categories
        .ProjectTo<CreateItemViewModel>(mapper.ConfigurationProvider)
        .ToArrayAsync();
}
