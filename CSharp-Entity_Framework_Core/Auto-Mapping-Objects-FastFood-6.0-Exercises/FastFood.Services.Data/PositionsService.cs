namespace FastFood.Services.Data;

using System.Collections.Generic;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

using FastFood.Core.ViewModels.Positions;
using FastFood.Data;
using FastFood.Models;

public class PositionsService : IPositionsService
{
    private readonly IMapper mapper;
    private readonly FastFoodContext context;

    public PositionsService(IMapper mapper,  FastFoodContext context)
    {
        this.mapper = mapper;
        this.context = context;
    }

    public async Task CreateAsync(CreatePositionInputModel inputModel)
    {
        Position position = mapper.Map<Position>(inputModel);
        await context.Positions.AddAsync(position);

        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<PositionsAllViewModel>> GetAllAsync()
        => await context.Positions
            .ProjectTo<PositionsAllViewModel>(mapper.ConfigurationProvider)
            .ToArrayAsync();
}
