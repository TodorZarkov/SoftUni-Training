namespace FastFood.Services.Data;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using FastFood.Core.ViewModels.Categories;
using FastFood.Data;
using FastFood.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CategoryService : ICategoryService
{
    private readonly IMapper mapper;
    private readonly FastFoodContext context;

    public CategoryService(IMapper mapper, FastFoodContext context)
    {
        this.mapper = mapper;
        this.context = context;
    }
    public async Task CreateAsync(CreateCategoryInputModel model)
    {
        Category category = mapper.Map<Category>(model);
        await context.Categories.AddAsync(category);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<CategoryAllViewModel>> GetAllAsync()
        => await context.Categories
        .ProjectTo<CategoryAllViewModel>(mapper.ConfigurationProvider)
        .ToArrayAsync();
}
